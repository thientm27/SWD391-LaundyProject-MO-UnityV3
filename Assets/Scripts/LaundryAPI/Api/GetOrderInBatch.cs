using System;
using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class GetOrderInBatch: HttpApi<OrderInBatchResponse>
    {
   
        protected override string ApiUrl { get; set; }
        private string startDay;
        private string endDay;

        public GetOrderInBatch(string id)
        {
            ApiUrl =  "api/v1/OrderInBatch/GetByID?entityId=" + id;
        }
        
        protected override IHttpRequest GetHttpRequest()
        {
            return NetworkManager.Instance.HttpGet(ApiUrl);
        }
    }
}