using System;
using System.Collections.Generic;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class OrderInBatchResponse : IResponseData
    {
        public int totalItemsCount { get; set; }
        public int pageSize { get; set; }
        public int totalPagesCount { get; set; }
        public int pageIndex { get; set; }
        public bool next { get; set; }
        public bool previous { get; set; }
        public List<BatchInfo> items { get; set; }
        public class BatchInfo
        {
            public string orderInBatchId { get; set; }
            public Batch batch { get; set; }
            public Order order { get; set; }
            public object creationDate { get; set; }
            public object modificationDate { get; set; }
            public string batchId { get; set; }
            public string orderId { get; set; }
            public string status { get; set; }
        }
        
        public class Batch
        {
            public string batchId { get; set; }
            public object driver { get; set; }
            public List<object> orderInBatch { get; set; }
            public DateTime creationDate { get; set; }
            public object modificationDate { get; set; }
            public string driverId { get; set; }
            public string type { get; set; }
            public object fromTime { get; set; }
            public object toTime { get; set; }
            public string status { get; set; }
        }


        public class Order
        {
            public string orderId { get; set; }
            public object building { get; set; }
            public object store { get; set; }
            public string note { get; set; }
            public string status { get; set; }
            public int numberOfPackage { get; set; }
            public object customer { get; set; }
            public List<object> orderDetails { get; set; }
            public List<object> payments { get; set; }
        }
    }
}