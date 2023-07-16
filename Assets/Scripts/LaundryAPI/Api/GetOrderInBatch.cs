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

        // f44e51e1-d3b8-4e5b-8862-30d17cd9f1e9
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