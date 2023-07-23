using System.Collections.Generic;
using LaundryAPI.ResponseModels;
using SystemApp;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class OrderDisplay : MonoBehaviour
    {
        public UnityAction<string, int> onClickSubmitOrder;
        public UnityAction<int> onClickViewOrder;
        public SystemApp.Model fakeData;
        [SerializeField] private GameObject batchItemDisplay;
        [SerializeField] private Transform displayContainer;
        private List<GameObject> itemBatchList;

        private bool isInitted = false;
        public void InitListOrderV2(List<OrderInBatchResponse.BatchInfo> items, string driveId = "")
        {
            // CLEAR OLDs
            if (itemBatchList == null)
            {
                itemBatchList = new List<GameObject>();
            }
            // else
            // {
            //     foreach (var item in itemBatchList)
            //     {
            //         Destroy(item);
            //     }
            // }


            var index = 0;
            foreach (var item in items)
            {
   
                if (item.order != null)
                {
                    // foreach (var order in item.order)
                    // // {
                    //     Debug.Log(order.orderId);
                    //     Debug.Log(order.status);
                    if (isInitted)
                    {
                        if (index >= itemBatchList.Count) // call out range -> create new
                        {
                            var obj = Instantiate(batchItemDisplay, displayContainer);
                            var controller = obj.GetComponent<OrderItem>();

                            controller.InitItem(index, item.orderId, onClickSubmitOrder
                                , item.order.customer.ToString(),
                                item.order.building.ToString(),
                                item.order.payments.ToString(), item.order.note, item.order.status == "Done");
                            itemBatchList.Add(obj);
                        }
                        else // already
                        {
                            itemBatchList[index].GetComponent<OrderItem>().UpdateStatus(item.order.status == "Done");
                        }
                    }
                    else
                    {
                        var obj = Instantiate(batchItemDisplay, displayContainer);
                        var controller = obj.GetComponent<OrderItem>();

                        controller.InitItem(index, item.orderId, onClickSubmitOrder
                            , "None",
                            "None",
                            "", item.order.note,item.order.status == "Done");
                        itemBatchList.Add(obj);
                    }

                    index++;
                    // }
                }
            }

            isInitted = true;
        }

        // public void InitListOrder(List<BatchTodayResponse.ItemBatchToday> items, string driveId = "")
        // {
        //     // CLEAR OLD
        //     if (itemBatchList == null)
        //     {
        //         itemBatchList = new List<GameObject>();
        //     }
        //     // else
        //     // {
        //     //     foreach (var item in itemBatchList)
        //     //     {
        //     //         Destroy(item);
        //     //     }
        //     // }
        //
        //
        //     var index = 0;
        //     foreach (var item in items)
        //     {
        //         if (string.IsNullOrEmpty(item.driverId))
        //         {
        //             continue;
        //         }
        //
        //         if (item.driverId != driveId)
        //         {
        //             continue;
        //         }
        //
        //         if (item.orderInBatch != null)
        //         {
        //             foreach (var order in item.orderInBatch)
        //             {
        //                 Debug.Log(order.orderId);
        //                 Debug.Log(order.status);
        //                 if (isInitted)
        //                 {
        //                     if (index >= itemBatchList.Count) // call out range -> create new
        //                     {
        //                         var obj = Instantiate(batchItemDisplay, displayContainer);
        //                         var controller = obj.GetComponent<OrderItem>();
        //
        //                         controller.InitItem(index, order.orderId, onClickSubmitOrder
        //                             , "None",
        //                             "None",
        //                             "None", order.note,order.status == "Done");
        //                         itemBatchList.Add(obj);
        //                     }
        //                     else // already
        //                     {
        //                         itemBatchList[index].GetComponent<OrderItem>().UpdateStatus(order.status == "Done");
        //                     }
        //                 }
        //                 else
        //                 {
        //                     var obj = Instantiate(batchItemDisplay, displayContainer);
        //                     var controller = obj.GetComponent<OrderItem>();
        //
        //                     controller.InitItem(index, order.orderId, onClickSubmitOrder
        //                         , "None",
        //                         "None",
        //                         "", order.status == "Done");
        //                     itemBatchList.Add(obj);
        //                 }
        //
        //                 index++;
        //             }
        //         }
        //     }
        //
        //     isInitted = true;
        // }
    }
}