using System;
using System.Net;
using Newtonsoft.Json;
using WebClientProject.Model;

namespace WebClientProject
{
    public class WebClientService
    {
        readonly string _remoteAddress;

        public WebClientService()
        {
            //your server ip and port
            _remoteAddress = "http://123.123.123.123:1234/";
        }

        public ServiceResult Login(Login login)
        {
            var webClient = new WebClient();
            try
            {
                var data = JsonConvert.SerializeObject(login);
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var json = webClient.UploadString(new Uri(_remoteAddress + "api/auth/PostToken"), "POST", data);
                var result = JsonConvert.DeserializeObject<ServiceResult>(json);
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
                var client = new WebClient();
                var data = JsonConvert.SerializeObject(document);
                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                //sample api endpoint address
                var json = client.UploadString(new Uri(_remoteAddress + "api/Financial/PostAddDoc"), "POST", data);
                var result = JsonConvert.DeserializeObject<ServiceResult>(json);
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
                var client = new WebClient();
                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                //sample api endpoint address
                var json = client.UploadString(
                    new Uri(_remoteAddress + $"api/Financial/PostRemoveDoc?orgdocId={documentId}"), "POST");
                var result = JsonConvert.DeserializeObject<ServiceResult>(json);
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