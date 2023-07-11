using Newtonsoft.Json;

namespace BaseHttp.Api
{
    public interface IResponseData
    {
    }

    /// <summary>
    /// The most simple data structure from api response
    /// </summary>
    public class BasicData : IResponseData
    {
        public int code;
        public object data;
    }

    public class BasicStringData : IResponseData
    {
        public int code;
        public string data;
    }


}