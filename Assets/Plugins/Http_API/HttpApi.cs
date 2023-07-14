using System;
using Cysharp.Threading.Tasks;
using Duck.Http.Service;
using Newtonsoft.Json;
using UnityEngine;

namespace BaseHttp.Api
{
    /// <summary>
    /// Represent to an API
    /// </summary>
    public interface IHttpApi
    {
    }

    [Serializable]
    public class BasicError : IResponseData
    {
        // public long timestamp;
        public int code;

        // public string error;
        public string message;
    }

    public abstract class HttpApi<T> : IHttpApi where T : class, IResponseData
    {
        public enum JsonParser
        {
            JsonUtility,
            JsonNet // for complex structure ex nested list
        }

        protected abstract string ApiUrl { get; set; }

        protected abstract IHttpRequest GetHttpRequest();

        public string ErrorMessage { get; internal set; }
        public BasicError Error { get; internal set; }

        protected JsonParser jsonParser = JsonParser.JsonUtility;

        public long StatusCode { get; set; }

        public HttpApi<T> UseJsonParser(JsonParser parser)
        {
            jsonParser = parser;
            return this;
        }

        public virtual UniTask<T> Send()
        {
            var s = new UniTaskCompletionSource<T>();
            Send(t => { s.TrySetResult(t); },
                e => s.TrySetResult(null)); //ignore exception temporarily, we handle errors on NetworkManager
            return s.Task;
        }

        public virtual UniTask<T> TryCatchSend()
        {
            var s = new UniTaskCompletionSource<T>();
            Send(t => { s.TrySetResult(t); },
                e => { s.TrySetException(new Exception(e)); });
            return s.Task;
        }

        public virtual void Send(Action<T> onSuccess, Action<string> onError = null)
        {
            GetHttpRequest()
                .OnSuccess(r => { OnSuccess(r, onSuccess, onError); })
                .OnError(r => { OnError(r, onError); })
                .Send();
        }

        protected virtual void OnSuccess(HttpResponse r, Action<T> onSuccess, Action<string> onError)
        {
            StatusCode = r.StatusCode;
            T obj = null;
            
            try
            {
                Debug.Log(typeof(T).ToString() + " : " + r.Text);
                obj = ParseJson<T>(r.Text);
                Debug.Log(r.Text);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Debug.LogError($"[HttpRequestUtils] -- error {ErrorMessage}");
                onError?.Invoke(ErrorMessage);
                return;
            }

            onSuccess?.Invoke(obj);

            Debug.Log(typeof(T).ToString() + " parsed : " + JsonConvert.SerializeObject(obj));
        }

        // protected TR ParseJson<TR>(string json) where TR : class, IResponseData
        // {
        //     TR obj = null;
        //     switch (jsonParser)
        //     {
        //         case JsonParser.JsonUtility:
        //             obj = JsonUtility.FromJson<TR>(json);
        //             break;
        //         case JsonParser.JsonNet:
        //         {
        //             var settings = new JsonSerializerSettings
        //             {
        //                 NullValueHandling = NullValueHandling.Ignore,
        //                 MissingMemberHandling = MissingMemberHandling.Ignore
        //             };
        //             obj = JsonConvert.DeserializeObject<TR>(json, settings);
        //             break;
        //         }
        //     }
        //
        //     return obj;
        // }
        protected virtual TR ParseJson<TR>(string json) where TR : class, IResponseData
        {
            TR obj = null;
            try
            {
                obj = JsonConvert.DeserializeObject<TR>(json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error deserializing JSON: {e.Message}");
            }

            return obj;
        }
        protected virtual void OnError(HttpResponse r, Action<string> onError)
        {
            StatusCode = r.StatusCode;
            ErrorMessage = r.Error;
            if (string.IsNullOrEmpty(r.Text))
            {
                onError?.Invoke(ErrorMessage);
                return;
            }

            try
            {
                Error = ParseJson<BasicError>(r.Text);
                ErrorMessage = Error.message;
            }
            catch (Exception e)
            {
            }

            onError?.Invoke(ErrorMessage);
        }
    }
}