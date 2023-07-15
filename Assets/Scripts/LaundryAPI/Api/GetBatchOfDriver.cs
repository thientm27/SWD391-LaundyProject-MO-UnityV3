using System;
using System.Collections.Generic;
using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class GetBatchOfDriver: HttpApi<BatchTodayResponse>
    {
   
        protected override string ApiUrl { get; set; }
        private string startDay;
        private string endDay;
        private List<string> driverId;

        public GetBatchOfDriver(string idDriver)
        {
            ApiUrl =  "api/v1/Batch/GetListWithFilter/0/10";
            // Tạo ngày kết thúc là ngày hiện tại
            startDay = DateTime.Now.ToString("yyyy-MM-dd");
            // Tạo ngày bắt đầu là 1 tháng trước ngày kết thúc
            endDay = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            driverId = new();
            driverId.Add(idDriver);
        }

     

        protected override IHttpRequest GetHttpRequest()
        {
            JSONObject data = new JSONObject();
            data.Add("fromDate", startDay);
            data.Add("toDate", endDay);

            JSONArray driverIdArray = new JSONArray();
            foreach (string id in driverId)
            {
                driverIdArray.Add(id);
            }
            data.Add("driverId", driverIdArray);

            return NetworkManager.Instance.HttpPost(ApiUrl, data);
        }
    }
}