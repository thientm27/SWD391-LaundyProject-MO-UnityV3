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
            public List<object> orderInBatch { get; set; }
            public object driverId { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public object date { get; set; }
        }
    }
}