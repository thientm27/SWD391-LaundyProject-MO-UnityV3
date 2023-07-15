using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class GetUserInformation: HttpApi<UserInformation>
    {
        protected override string ApiUrl { get; set; }


        public GetUserInformation(string id)
        {
            ApiUrl = "api/v1/Driver/GetByID/" + id;
        }
        
        protected override IHttpRequest GetHttpRequest()
        {
            return NetworkManager.Instance.HttpGet(ApiUrl);
        }
    }
}