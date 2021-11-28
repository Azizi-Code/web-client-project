using Newtonsoft.Json;
using ServiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ServiceManager
{
    public class MyServiceManager
    {
        string _RemoteAddress;
        public MyServiceManager(string remoteAddress)
        {
            _RemoteAddress = remoteAddress;
        }
        public MyServiceManager()
        {
            _RemoteAddress = "http://217.218.62.42:8091/";
        }
        public ServiceResult Login(Login login)
        {
            WebClient client = new WebClient();
            try
            {

                string data = JsonConvert.SerializeObject(login);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var json = client.UploadString(new Uri(_RemoteAddress + "api/auth/PostToken"), "POST", data);
                ServiceResult result = JsonConvert.DeserializeObject<ServiceResult>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message,
                };
            }
        }
        public ServiceResult SendDocument(Document document, string token)
        {
            try
            {
                WebClient client = new WebClient();
                string data = JsonConvert.SerializeObject(document);
                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var json = client.UploadString(new Uri(_RemoteAddress + "api/Financial/PostAddDoc"), "POST", data);
                ServiceResult result = JsonConvert.DeserializeObject<ServiceResult>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message,
                };
            }
        }
        public ServiceResult DeleteDocument(string documentId, string token)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                //client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var json = client.UploadString(new Uri(_RemoteAddress + $"api/Financial/PostRemoveDoc?orgdocId={documentId}"), "POST");
                ServiceResult result = JsonConvert.DeserializeObject<ServiceResult>(json);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message,
                };
            }
        }
    }
}
