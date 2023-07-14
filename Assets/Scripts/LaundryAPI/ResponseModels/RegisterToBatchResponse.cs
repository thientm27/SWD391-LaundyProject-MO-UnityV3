using System;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class RegisterToBatchResponse : IResponseData
    {
        public string message;
    }
}