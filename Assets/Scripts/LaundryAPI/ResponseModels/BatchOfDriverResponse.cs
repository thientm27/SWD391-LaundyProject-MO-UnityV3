using System;
using System.Collections.Generic;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class BatchOfDriverResponse : IResponseData
    {
        public int totalItemsCount { get; set; }
        public int pageSize { get; set; }
        public int totalPagesCount { get; set; }
        public int pageIndex { get; set; }
        public bool next { get; set; }
        public bool previous { get; set; }
        public List<Item> items { get; set; }
        public class Driver
        {
            public string driverId { get; set; }
            public string fullName { get; set; }
            public string email { get; set; }
            public string phoneNumber { get; set; }
            public float wallet { get; set; }
            public float cod { get; set; }
        }

        public class Item
        {
            public string batchId { get; set; }
            public Driver driver { get; set; }
            public List<object> orderInBatch { get; set; }
            public string driverId { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public object date { get; set; }
        }

     
    }
}