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

        // Batch Today
        public UnityAction<BatchTodayResponse> onPostBatchToday;
        public UnityAction onPostBatchTodayFail;
        
        // Register to batch
        public UnityAction<RegisterToBatchResponse> onPostRegisterToBatch;
        public UnityAction onPostRegisterToBatchFail;
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

        public void GetBatchToday()
        {
            PostBatchTodayHttp data = new PostBatchTodayHttp();
            data.Send(p =>
            {
                onPostBatchToday?.Invoke(p);
            }, _ => { onPostBatchTodayFail?.Invoke(); });
        }
        public void RegisterToBatch(string batchId)
        {
            PostRegisterToBatch data = new PostRegisterToBatch(batchId);
            data.Send(p =>
            {
                onPostRegisterToBatch?.Invoke(p);
            }, _ => { onPostRegisterToBatchFail?.Invoke(); });
        }
    }
}