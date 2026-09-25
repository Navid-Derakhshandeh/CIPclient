using AuthService;
using Grpc.Core;
using Grpc.Net.Client;
using static AuthService.AuthService;

namespace CIPclient
{
    public partial class Main : Form
    {

        private readonly AuthServiceClient auth;


        public Main()
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



            auth =
                new AuthServiceClient(channel);
        }



        private void btnsignup_Click(
            object sender,
            EventArgs e)
        {
            signup frm =
                new signup();

            frm.Show();
        }



        private async void btnlogin_Click(
            object sender,
            EventArgs e)
        {

            string username =
                txtuser.Text.Trim();


            string password =
                txtpass.Text.Trim();



            try
            {

                var response =
                    await auth.LoginAsync(
                        new LoginRequest
                        {
                            Username = username,
                            Password = password
                        });



                if (response.Success)
                {

                    // SAVE JWT TOKEN

                    Session.Session.Token =
                        response.Token;



                    var headers =
                        new Metadata
                        {
                            {
                                "Authorization",
                                $"Bearer {Session.Session.Token}"
                            }
                        };



                    var userInfo =
                        await auth.GetUserInfoAsync(
                            new UserInfoRequest(),
                            headers);



                    MessageBox.Show(
                        $"Welcome {userInfo.Username}");



                    Modbus frm =
                        new Modbus();


                    frm.Show();

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
            catch (Exception ex)
            {

                MessageBox.Show(
                    ex.Message);

            }
        }



        private void Main_Load(
            object sender,
            EventArgs e)
        {

        }
    }
}