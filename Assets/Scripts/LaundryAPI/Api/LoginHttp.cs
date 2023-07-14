using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class LoginHttp : HttpApi<LoginResponse>
    {
        protected override string ApiUrl { get; set; }
        private string email;
        private string password;

        public LoginHttp(string email, string password)
        {
            ApiUrl = "api/v1/User/Login";
            this.email = email;
            this.password = password;
        }


        protected override IHttpRequest GetHttpRequest()
        {
            JSONObject data = new JSONObject();
            data.Add("email", email);
            data.Add("password", password);
            return NetworkManager.Instance.HttpPost(ApiUrl, data);
        }
    }
}