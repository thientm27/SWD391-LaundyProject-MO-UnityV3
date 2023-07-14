﻿using BaseHttp.Api;
using BaseHttp.Core;
using Duck.Http.Service;
using LaundryAPI.ResponseModels;
using SimpleJSON;

namespace LaundryAPI.Api
{
    public class GetAllBatchHttp : HttpApi<AllBatchResponse>
    {
  
        protected override string ApiUrl { get; set; }
        private string email;
        private string password;

        public GetAllBatchHttp()
        {
            ApiUrl = "api/v1/Batch/GetAll?pageIndex=0&pageSize=10";
        }



        protected override IHttpRequest GetHttpRequest()
        {
            return NetworkManager.Instance.HttpGet(ApiUrl);
        }
    }
}