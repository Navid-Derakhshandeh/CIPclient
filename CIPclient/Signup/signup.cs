using AuthService;
using Grpc.Core;
using Grpc.Net.Client;
using static AuthService.AuthService;

namespace CIPclient
{
    public partial class signup : Form
    {
        private readonly AuthServiceClient auth;

        public signup()
        {
            InitializeComponent();

            var channel = GrpcChannel.ForAddress("http://localhost:5000",
            new GrpcChannelOptions
            {
                HttpHandler =
                    new SocketsHttpHandler
                    {
                        EnableMultipleHttp2Connections = true
                    }
            });

            auth =
                new AuthServiceClient(channel);
        }


        private async void btnregister_Click(object sender, EventArgs e)
        {
            string username =
                txtuser.Text ?? "";

            string password =
                txtpass.Text ?? "";


            try
            {
                var response =
                    await auth.SignupAsync(
                        new SignupRequest
                        {
                            Username = username,
                            Password = password
                        });


                if (response.Success)
                {
                    MessageBox.Show(
                        response.Message);

                    Modbus frm = new Modbus();
                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        response.Message);
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show(
                    ex.Status.Detail);
            }
        }
    }
}