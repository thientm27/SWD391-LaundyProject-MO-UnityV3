using System;
using System.Collections.Generic;
using LaundryAPI.ResponseModels;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class BatchDisplay : MonoBehaviour
    {
        public UnityAction<int> onClickRegister;
        [SerializeField] private GameObject batchItemDisplay;
        [SerializeField] private Transform displayContainer;
        private List<GameObject> itemBatchList;


        [Obsolete("method need to update",false)]
        public void InitListOfBatchDisplay(List<BatchTodayResponse.ItemBatchToday> items, string userId)
        {
            // CLEAR OLD
            if (itemBatchList == null)
            {
                itemBatchList = new List<GameObject>();
            }
            else
            {
                foreach (var item in itemBatchList)
                {
                    Destroy(item);
                }
            }

            var index = 0;
            foreach (var item in items)
            {
                var obj = Instantiate(batchItemDisplay, displayContainer);
                var controller = obj.GetComponent<BatchItem>();
                int validStatus = 0;
                Debug.Log("INIT BATCH");
                Debug.Log(userId);
                if (userId == (string)item.driverId)
                {
                    validStatus = 1;
                }
                else if (item.driverId != null)
                {
                    validStatus = -1;
                }
                
                controller.InitItem(item.type, item.status, validStatus, index, onClickRegister);
                
                itemBatchList.Add(obj);
                index++;
            }
        }
    }
}