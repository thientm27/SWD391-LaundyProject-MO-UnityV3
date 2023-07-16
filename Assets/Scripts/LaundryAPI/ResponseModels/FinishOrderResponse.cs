using System;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class FinishOrderResponse : IResponseData
    {
        public string message;
    }
}