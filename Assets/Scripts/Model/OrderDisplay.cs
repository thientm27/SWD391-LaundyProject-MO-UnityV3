using System.Collections.Generic;
using LaundryAPI.ResponseModels;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class OrderDisplay : MonoBehaviour
    {
        public UnityAction<int> onClickSubmitOrder;
        public UnityAction<int> onClickViewOrder;
        [SerializeField] private GameObject batchItemDisplay;
        [SerializeField] private Transform displayContainer;
        private List<GameObject> itemBatchList;

        public void InitListOrder(List<BatchTodayResponse.ItemBatchToday> items)
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
                if (item.orderInBatch != null)
                {
                    foreach (var order in item.orderInBatch)
                    {
                        var obj = Instantiate(batchItemDisplay, displayContainer);
                        var controller = obj.GetComponent<OrderItem>();

                        controller.InitItem(index, onClickViewOrder, onClickSubmitOrder);
                        itemBatchList.Add(obj);
                        index++;
                    }
                }
            }
        }
    }
}