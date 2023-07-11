using System;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class LoginResponse : IResponseData
    {
        public string userId;
        public string jwt;
        public string refreshToken;
    }
}