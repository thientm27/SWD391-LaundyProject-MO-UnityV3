using System;
using System.Collections.Generic;
using BaseHttp.Api;

namespace LaundryAPI.ResponseModels
{
    [Serializable]
    public class UserInformation : IResponseData
    {
        public float wallet { get; set; }
        public float cod { get; set; }
        public List<Batch> batches { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string phoneNumber { get; set; }
        public object isAdmin { get; set; }
        public string refreshToken { get; set; }
        public DateTime expireTokenTime { get; set; }
        public string id { get; set; }
        public DateTime creationDate { get; set; }
        public string createdBy { get; set; }
        public DateTime modificationDate { get; set; }
        public string modificationBy { get; set; }
        public object deletionDate { get; set; }
        public object deleteBy { get; set; }
        public bool isDeleted { get; set; }
        
        public class Batch
        {
            public string driverId { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public object date { get; set; }
            public object driver { get; set; }
            public List<object> batchOfBuildings { get; set; }
            public List<object> orderInBatches { get; set; }
            public string id { get; set; }
            public DateTime creationDate { get; set; }
            public string createdBy { get; set; }
            public object modificationDate { get; set; }
            public object modificationBy { get; set; }
            public object deletionDate { get; set; }
            public object deleteBy { get; set; }
            public bool isDeleted { get; set; }
        }



    }
}