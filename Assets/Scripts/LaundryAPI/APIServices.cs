using System;
using System.Linq;
using BaseHttp.Core;
using LaundryAPI.Api;
using LaundryAPI.ResponseModels;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace LaudryAPI
{
    public class APIServices 
    {
        // LOGIN
        public UnityAction<LoginResponse> onLogin;
        public UnityAction onLoginFail;

        // GET ALL BATCHES
        public UnityAction<AllBatchResponse> onGetAllBatches;
        public UnityAction onGetAllBatchesFail;

        public void Login(string email, string password)
        {
            LoginHttp data = new LoginHttp(email, password);
            data.Send(p =>
            {
                NetworkManager.Instance.SigninResponse.accessToken = p.jwt;
                onLogin?.Invoke(p);
            }, _ => { onLoginFail?.Invoke(); });
        }

        public void GetAllBatch()
        {
            GetAllBatchHttp data2 = new GetAllBatchHttp();
            data2.Send(p => { onGetAllBatches?.Invoke(p); }, _ => { onGetAllBatchesFail?.Invoke(); });
        }
    }
}