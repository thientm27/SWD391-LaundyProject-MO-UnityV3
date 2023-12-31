using System;
using System.Collections.Generic;
using System.Linq;
using BaseHttp.Core;
using LaundryAPI.Api;
using LaundryAPI.ResponseModels;

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
        
        // Get batches  driver
        public UnityAction<UserInformation> onGetUserInformation;
        public UnityAction onGetUserInformationFail;    
        // Finish order
        public UnityAction<FinishOrderResponse> onFinishOrder;
        public UnityAction onFinishOrderFail;
        public void Login(string email, string password)
        {
            LoginHttp data = new LoginHttp(email, password);
            data.Send(p =>
            {
                NetworkManager.Instance.SigninResponse.accessToken = p.jwt;
                onLogin?.Invoke(p);
            }, _ => { onLoginFail?.Invoke(); });
        }
        
        public void FinishOrder(string id)
        {
            FinishOrder data2 = new FinishOrder(id);
            data2.Send(p => { onFinishOrder?.Invoke(p); }, _ => { onFinishOrderFail?.Invoke(); });
        }
        public void GetUserInformation(string id)
        {
            GetUserInformation data2 = new GetUserInformation(id);
            data2.Send(p => { onGetUserInformation?.Invoke(p); }, _ => { onGetUserInformationFail?.Invoke(); });
        }
        public void GetOrderInBatch(List<string> myBatchId)
        {
            GetOrderInBatch data2 = new GetOrderInBatch(myBatchId);
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