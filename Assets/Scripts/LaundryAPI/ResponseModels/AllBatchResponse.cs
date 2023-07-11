using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class AllBatchResponse : IResponseData
    {
        [DataMember(Name = "totalItemsCount")]
        public int totalItemsCount { get; set; }

        [DataMember(Name = "pageSize")]
        public int pageSize { get; set; }

        [DataMember(Name = "totalPagesCount")]
        public int totalPagesCount { get; set; }

        [DataMember(Name = "pageIndex")]
        public int pageIndex { get; set; }

        [DataMember(Name = "next")]
        public bool next { get; set; }

        [DataMember(Name = "previous")]
        public bool previous { get; set; }

        [DataMember(Name = "items")]
        public List<Item> items { get; set; }
    }

    public class Driver
    {
        public string DriverId { get; set; }
        public object BatchResponses { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class OrderInBatchResponse
    {
        public string OrderInBatchId { get; set; }
        public object Batch { get; set; }
        public object Order { get; set; }
        public string BatchId { get; set; }
        public string OrderId { get; set; }
        public string Status { get; set; }
    }

    public class Item
    {
        public string BatchId { get; set; }
        public Driver Driver { get; set; }
        public List<OrderInBatchResponse> OrderInBatchResponses { get; set; }
        public string DriverId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}