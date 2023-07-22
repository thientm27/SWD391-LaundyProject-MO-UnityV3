using System;
using System.Collections.Generic;
using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class GetOrderInBatch : HttpApi<OrderInBatchResponse>
    {
        protected override string ApiUrl { get; set; }

        private List<string> batchIds;

        // f44e51e1-d3b8-4e5b-8862-30d17cd9f1e9
        public GetOrderInBatch(List<string> myBatchId)
        {
            ApiUrl = "api/v1/OrderInBatch/GetByID?entityId="; // update this
            batchIds = myBatchId;
        }

        protected override IHttpRequest GetHttpRequest()
        {
            JSONObject data = new JSONObject();
            JSONArray driverIdArray = new JSONArray();
            foreach (string id in batchIds)
            {
                driverIdArray.Add(id);
            }

            data.Add("batchId", driverIdArray);
            return NetworkManager.Instance.HttpPost(ApiUrl, data);
        }
    }
}