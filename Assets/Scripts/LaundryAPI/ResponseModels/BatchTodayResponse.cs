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
            public Driver driver { get; set; }
            public List<OrderInBatch> orderInBatch { get; set; }
            public DateTime creationDate { get; set; }
            public DateTime? modificationDate { get; set; }
            public string driverId { get; set; }
            public string type { get; set; }
            public object fromTime { get; set; }
            public object toTime { get; set; }
            public string status { get; set; }
        }
        public class OrderInBatch
        {
            public string orderInBatchId { get; set; }
            public object batch { get; set; }
            public object order { get; set; }
            public DateTime? creationDate { get; set; }
            public object modificationDate { get; set; }
            public string batchId { get; set; }
            public string orderId { get; set; }
            public string status { get; set; }

        }
    }
}