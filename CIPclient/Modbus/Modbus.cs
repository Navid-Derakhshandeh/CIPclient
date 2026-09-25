using Grpc.Core;
using Grpc.Net.Client;
using ModbusGrpc;

namespace CIPclient
{
    public partial class Modbus : Form
    {
        private readonly ModbusService.ModbusServiceClient client;
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
                if (string.IsNullOrEmpty(Session.Session.Token))
                {
                    MessageBox.Show(
                        "User is not logged in");

                    return;
                }
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
                var read =
                    await client.ReadHoldingRegistersAsync(
                        new ReadHoldingRegistersRequest
                        {
                            StartAddress = 0,
                            Quantity = 10
                        },
                        GetHeaders());

                    listoutput.Items.Clear();

                    for (int i = 0;
                         i < read.Registers.Count;
                         i++)
                    {
                        listoutput.Items.Add(
                            $"Register {i}: {read.Registers[i]}");
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
    }
}