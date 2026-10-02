using Grpc.Core;
using Grpc.Net.Client;
using ModbusGrpc;
using protocol_module.Protocol;
using zeromq_module.Interfaces;
using zeromq_module.ZeroMQ;


namespace CIPclient
{
    public partial class Modbus : Form
    {
        private readonly ModbusService.ModbusServiceClient client;
        private ZeroMqSubscriber? subscriber;
        private CancellationTokenSource?
            telemetryToken;
        public Modbus()
        {
            InitializeComponent();
            var channel =
                GrpcChannel.ForAddress(
                    "http://localhost:5000",
                    new GrpcChannelOptions
                    {
                        HttpHandler =
                            new SocketsHttpHandler
                            {
                                EnableMultipleHttp2Connections = true
                            }
                    });
            client =
                new ModbusService.ModbusServiceClient(channel);
        }
        private Metadata GetHeaders()
        {
            return new Metadata
            {
                {
                    "Authorization",
                    $"Bearer {Session.Session.Token}"
                }
            };
        }
        private async void Modbus_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(
                    Session.Session.Token))
                {
                    MessageBox.Show(
                        "User is not logged in");
                    return;
                }
                //----------------------------------------------
                // ZeroMQ ===== Data Stream
                //----------------------------------------------
                subscriber =
                    new ZeroMqSubscriber(
                        "tcp://localhost:6003",
                        "telemetry");
                // allow ZeroMQ SUB socket connect
                await Task.Delay(1000);
                telemetryToken =
                    new CancellationTokenSource();
                listoutput.Items.Add(
                    "ZeroMQ Subscriber Started");
                listoutput.Items.Add(
                    "Waiting for telemetry...");
                Task.Run(() =>
                    ReceiveTelemetry(
                        telemetryToken.Token));
                // CONNECT
                var connect =
                    await client.ConnectAsync(
                        new ConnectRequest(),
                        GetHeaders());
                if (connect.Connected)
                {
                    MessageBox.Show(
                        "Modbus Connected");
                }
                else
                {
                    MessageBox.Show(
                        "Modbus Connection Failed");
                    return;
                }
                // READ REGISTERS
                //var read =
                //    await client.ReadHoldingRegistersAsync(
                //        new ReadHoldingRegistersRequest
                //        {
                //            StartAddress = 0,
                //            Quantity = 10
                //        },
                //        GetHeaders());
                //listoutput.Items.Clear();
                //for (int i = 0;
                //     i < read.Registers.Count;
                //     i++)
                //{
                //    listoutput.Items.Add(
                //        $"Register {i}: {read.Registers[i]}");
                //}
            }
            catch (RpcException ex)
            {
                MessageBox.Show(
                    $"gRPC Error: {ex.Status.Detail}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
        private async Task ReceiveTelemetry(
            CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    // -----------------------------------------
                    // 1. Receive JSON from ZeroMQ
                    // -----------------------------------------
                    string json =
                        await subscriber!
                        .SubscribeAsync();
                    Console.WriteLine(
                        "Telemetry received");
                    Console.WriteLine(json);
                    // -----------------------------------------
                    // 2. JSON -> ProtocolMessage
                    // -----------------------------------------
                    ProtocolMessage message =
                        ProtocolSerializer
                        .Deserialize(json);
                    BeginInvoke(() =>
                    {
                        // -----------------------------------------
                        // 3. Read protocol data
                        // -----------------------------------------
                        listoutput.Items.Add(
                            "----------------------");
                        listoutput.Items.Add(
                            "Parsed Data");
                        listoutput.Items.Add(
                            $"Type: {message.Type}");
                        listoutput.Items.Add(
                            $"Source: {message.Source}");
                        listoutput.Items.Add(
                            $"Device: {message.DeviceId}");
                        listoutput.Items.Add(
                            $"Operation: {message.Data.Operation}");
                        listoutput.Items.Add(
                            $"Address: {message.Data.Address}");
                        listoutput.Items.Add(
                            $"Quantity: {message.Data.Quantity}");
                        // -----------------------------------------
                        // 4. Client gets the REAL Modbus values
                        // -----------------------------------------
                        int[] registers =
                            message.Data.Values;
                        for (int i = 0;
                            i < registers.Length;
                            i++)
                        {
                            listoutput.Items.Add(
                                $"Register {i}: {registers[i]}");
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    BeginInvoke(() =>
                    {
                        listoutput.Items.Add(
                            $"Telemetry Error: {ex.Message}");
                    });
                }
            }
        }
        private async void btnsend_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                int value = 0;
                if (!int.TryParse(
                    txtinput.Text,
                    out value))
                {
                    MessageBox.Show(
                        "Enter valid number");
                    return;
                }
                var write =
                    await client.WriteMultipleRegistersAsync(
                        new WriteMultipleRegistersRequest
                        {
                            Address = 9,
                            Values =
                            {
                                value
                            }
                        },
                        GetHeaders());
                if (write.Success)
                {
                    MessageBox.Show(
                        write.Message);
                }
                else
                {
                    MessageBox.Show(
                        "Write failed");
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show(
                    $"gRPC Error: {ex.Status.Detail}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            telemetryToken?
                .Cancel();
            subscriber?
                .Dispose();
            base.OnFormClosing(e);
        }
    }
}