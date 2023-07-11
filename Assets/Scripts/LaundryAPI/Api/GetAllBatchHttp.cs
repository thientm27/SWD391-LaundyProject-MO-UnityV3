using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class GetAllBatchHttp : HttpApi<AllBatchResponse>
    {
        protected override string ApiUrl => "api/v1/Batch/GetAll?pageIndex=0&pageSize=10";

        private string email;
        private string password;

        public GetAllBatchHttp()
        {
        }

        protected override IHttpRequest GetHttpRequest()
        {
            return NetworkManager.Instance.HttpGet(ApiUrl);
        }
    }
}