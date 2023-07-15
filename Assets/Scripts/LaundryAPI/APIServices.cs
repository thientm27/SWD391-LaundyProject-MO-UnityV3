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
        
        // Get batches driver
        public UnityAction<BatchOfDriverResponse> onGetBatchOfDriver;
        public UnityAction onGetBatchOfDriverFail;
        
        // Get batches  driver
        public UnityAction<OrderInBatchResponse> onGetOrderInBatch;
        public UnityAction onGetOrderInBatchFail;
        public void Login(string email, string password)
        {
            LoginHttp data = new LoginHttp(email, password);
            data.Send(p =>
            {
                NetworkManager.Instance.SigninResponse.accessToken = p.jwt;
                onLogin?.Invoke(p);
            }, _ => { onLoginFail?.Invoke(); });
        }
        public void GetOrderInBatch(string id)
        {
            GetOrderInBatch data2 = new GetOrderInBatch(id);
            data2.Send(p => { onGetOrderInBatch?.Invoke(p); }, _ => { onGetOrderInBatchFail?.Invoke(); });
        }
        public void GetAllBatchOfDriver(string id)
        {
            GetBatchOfDriver data2 = new GetBatchOfDriver(id);
            data2.Send(p => { onGetBatchOfDriver?.Invoke(p); }, _ => { onGetBatchOfDriverFail?.Invoke(); });
        }
        public void GetAllBatch()
        {
            GetAllBatch data2 = new GetAllBatch();
            data2.Send(p => { onGetAllBatches?.Invoke(p); }, _ => { onGetAllBatchesFail?.Invoke(); });
        }

        public void GetBatchToday()
        {
            GetBatchToday data = new GetBatchToday();
            data.Send(p =>
            {
                onPostBatchToday?.Invoke(p);
            }, _ => { onPostBatchTodayFail?.Invoke(); });
        }
        public void RegisterToBatch(string batchId)
        {
            UpdateRegisterToBatch data = new UpdateRegisterToBatch(batchId);
            data.Send(p =>
            {
                onPostRegisterToBatch?.Invoke(p);
            }, _ => { onPostRegisterToBatchFail?.Invoke(); });
        }
    }
}