using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class PostRegisterToBatch : HttpApi<RegisterToBatchResponse>
    {
        protected override string ApiUrl { get; set; }

        // private string id;

        public PostRegisterToBatch(string batchId)
        {
            ApiUrl = "api/v1/Driver/RegisterToBatch/"+batchId;
            // id = batchId;
        }

        protected override IHttpRequest GetHttpRequest()
        {
            return NetworkManager.Instance.HttpGet(ApiUrl);
        }
    }
}