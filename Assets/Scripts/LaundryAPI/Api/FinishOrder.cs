using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;

namespace LaundryAPI.Api
{
    public class FinishOrder: HttpApi<FinishOrderResponse>
    {
        protected override string ApiUrl { get; set; }


        public FinishOrder(string id)
        {
            ApiUrl = "api/v1/Order/FinishOrder/" + id;
        }
        
        protected override IHttpRequest GetHttpRequest()
        {
            return NetworkManager.Instance.HttpGet(ApiUrl);
        }
    }
}