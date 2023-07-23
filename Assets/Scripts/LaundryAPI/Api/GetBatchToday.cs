using System;
using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;
using UnityEngine;

namespace LaundryAPI.Api
{
    public class GetBatchToday: HttpApi<BatchTodayResponse>
    {
   
        protected override string ApiUrl { get; set; }
        private string startDay;
        private string endDay;

        public GetBatchToday()
        {
            ApiUrl =  "api/v1/Batch/GetListWithFilter/0/50";
            // Tạo ngày kết thúc là ngày hiện tại
            startDay = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            // Tạo ngày bắt đầu là 1 tháng trước ngày kết thúc
            endDay = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        }

        
        protected override IHttpRequest GetHttpRequest()
        {
            JSONObject data = new JSONObject();
            data.Add("fromDate", startDay);
            data.Add("toDate", endDay);
            return NetworkManager.Instance.HttpPost(ApiUrl, data);
        }
    }
}