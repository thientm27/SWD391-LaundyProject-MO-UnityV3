using UnityEngine;
using BaseHttp.Utils;
using Duck.Http;
using Duck.Http.Service;
using System;
using SimpleJSON;

namespace BaseHttp.Core
{
    public class NetworkManager : AutoSingletonMono<NetworkManager>
    {
        [Serializable]
        public enum Mode
        {
            LOCAL,
            DEV,
            UAT,
            STAGE,
            PROD
        }

        [Serializable]
        public class ServerInfo
        {
            [SerializeField] public string apiServer = "";

            [SerializeField] public string apiGamePath = "/api/v1";

        }

        [Serializable]
        public class DictionaryServerMode : SerializableDictionary<Mode, ServerInfo>
        {
        }

        ///////////////////////////////////////////////////////////////////////////////

        [SerializeField] private CustomSigninResponse signinResponse = new CustomSigninResponse();

        [SerializeField]
        public CustomSigninResponse SigninResponse
        {
            get { return signinResponse; }
            set { signinResponse = value; }
        }

        [SerializeField] private DictionaryServerMode dictionaryServers = new DictionaryServerMode();

        [SerializeField] public Mode mode = Mode.DEV;

        [SerializeField]
        private ServerInfo serverInfo = new ServerInfo();

        public override void Awake()
        {
            base.Awake();
            ServerInfo valueServer;
            dictionaryServers.TryGetValue(mode, out valueServer);
            if (valueServer != null)
            {
                serverInfo = dictionaryServers[mode];
            }
            DontDestroyOnLoad(gameObject);        
        }

        //////////////////////////////////////////////
        ///---------------Get Method---------------///
        //////////////////////////////////////////////
        public IHttpRequest HttpGet(string functionPath)
        {
            string url = new Uri(serverInfo.apiServer).Append(serverInfo.apiGamePath)
                .Append(functionPath)
                .AbsoluteUri;
            Debug.Log("[NetworkManager] -- HttpGet: " + url);
            var request = Http.Get(url)
                .SetHeader("Content-Type", "application/json")
                .SetHeader("Authorization", string.Format("Bearer {0}", signinResponse.accessToken));

            request.OnSuccess(r =>
                {
                    Debug.Log($"[NetworkManager] {functionPath}-- success: {r.Text}");
                })
                .OnError(r => { Debug.LogError($"[NetworkManager] -- error : {r.Error}"); });
            return request;
        }
        ///////////////////////////////////////////////
        ///---------------Post Method---------------///
        ///////////////////////////////////////////////
        public IHttpRequest HttpPost(string functionPath, JSONObject jsonObj)
        {
            string url = new Uri(serverInfo.apiServer).Append(serverInfo.apiGamePath)
                .Append(functionPath)
                .AbsoluteUri;
            Debug.Log("NetworkManager -- HttpPost: " + url + $" -- {jsonObj}");

            var request = Http.PostJson(url, jsonObj?.ToString())
                .SetHeader("Content-Type", "application/json")
                .SetHeader("Authorization", string.Format("Bearer {0}", signinResponse.accessToken));

            request.OnSuccess(r =>
                {
                    Debug.Log($"[NetworkManager] -- success: {r.Text}");
                })
                .OnError(r => { Debug.LogError($"[NetworkManager] -- error : {r.Error} - {r.Text}"); });

            return request;
        }

        public IHttpRequest HttpPost(string functionPath, string jsonString)
        {
            string url = new Uri(serverInfo.apiServer).Append(serverInfo.apiGamePath)
                .Append(functionPath)
                .AbsoluteUri;
            Debug.Log("NetworkManager -- HttpPost: " + url + $" -- {jsonString}");

            var request = Http.PostJson(url, jsonString.ToString())
                .SetHeader("Content-Type", "application/json")
                .SetHeader("Authorization", string.Format("Bearer {0}", signinResponse.accessToken));

            request.OnSuccess(r =>
            {
                Debug.Log($"[NetworkManager] -- success: {r.Text}");
            })
                .OnError(r => { Debug.LogError($"[NetworkManager] -- error : {r.Error} - {r.Text}"); });

            return request;
        }
        //////////////////////////////////////////////
        ///---------------Put Method---------------///
        //////////////////////////////////////////////
        public IHttpRequest HttpPut(string functionPath, JSONObject jsonObj)
        {
            string url = new Uri(serverInfo.apiServer).Append(serverInfo.apiGamePath)
                .Append(functionPath)
                .AbsoluteUri;
            Debug.Log("NetworkManager -- HttpPut: " + url);
            var request = Http.Put(url, jsonObj.ToString())
                .SetHeader("Content-Type", "application/json")
                .SetHeader("Authorization", string.Format("Bearer {0}", signinResponse.accessToken));
            request.OnSuccess(r =>
                {
                    Debug.Log($"[NetworkManager] -- success: {r.Text}");
                })
                .OnError(r => { Debug.LogError($"[NetworkManager] -- error : {r.Error}"); });

            return request;
        }

        public IHttpRequest HttpPut(string functionPath, string jsonString)
        {
            string url = new Uri(serverInfo.apiServer).Append(serverInfo.apiGamePath)
                .Append(functionPath)
                .AbsoluteUri;
            Debug.Log("NetworkManager -- HttpPut: " + url);
            var request = Http.Put(url, jsonString.ToString())
                .SetHeader("Content-Type", "application/json")
                .SetHeader("Authorization", string.Format("Bearer {0}", signinResponse.accessToken));
            request.OnSuccess(r =>
            {
                Debug.Log($"[NetworkManager] -- success: {r.Text}");
            })
                .OnError(r => { Debug.LogError($"[NetworkManager] -- error : {r.Error}"); });

            return request;
        }
        /////////////////////////////////////////////////
        ///---------------Delete Method---------------///
        /////////////////////////////////////////////////
        public IHttpRequest HttpDelete(string functionPath)
        {
            string url = new Uri(serverInfo.apiServer).Append(serverInfo.apiGamePath)
                .Append(functionPath)
                .AbsoluteUri;
            Debug.Log("NetworkManager -- HttpDelete: " + url);
            var request = Http.Delete(url)
                .SetHeader("Content-Type", "application/json")
                .SetHeader("Authorization", string.Format("Bearer {0}", signinResponse.accessToken));
            request.OnSuccess(r =>
                {
                    Debug.Log($"[NetworkManager] -- success: {r.Text}");
                })
                .OnError(r => { Debug.LogError($"[NetworkManager] -- error : {r.Error}"); });

            return request;
        }
    }
}