using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MobileCenterClient.Models.MobileCenter.Exceptions
{
    class FailedHttpResponseException : MobileCenterApiException
    {
        public HttpResponseMessage Response { get; }

        public FailedHttpResponseException(HttpResponseMessage response)
        {
            Response = response;
        }
    }
}
