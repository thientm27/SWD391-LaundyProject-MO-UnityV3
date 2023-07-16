using System;
using System.Collections.Generic;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class BatchTodayResponse: IResponseData
    {
        public int totalItemsCount { get; set; }
        public int pageSize { get; set; }
        public int totalPagesCount { get; set; }
        public int pageIndex { get; set; }
        public bool next { get; set; }
        public bool previous { get; set; }
        public List<ItemBatchToday> items { get; set; }
        public class ItemBatchToday
        {
            public string batchId { get; set; }
            public object driver { get; set; }
            public List<OrderInBatch> orderInBatch { get; set; }
            public object driverId { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public object date { get; set; }
        }
        public class OrderInBatch
        {
            public string batchId { get; set; }
            public string orderId { get; set; }
            public string status { get; set; }
            public object batch { get; set; }
            public object order { get; set; }
            public string id { get; set; }
            public object creationDate { get; set; }
            public object createdBy { get; set; }
            public object modificationDate { get; set; }
            public object modificationBy { get; set; }
            public object deletionDate { get; set; }
            public object deleteBy { get; set; }
            public bool isDeleted { get; set; }
        }
    }
}