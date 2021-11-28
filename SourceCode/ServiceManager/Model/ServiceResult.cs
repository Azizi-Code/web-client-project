using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceManager.Model
{
    public class ServiceResult
    {
        public string Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
