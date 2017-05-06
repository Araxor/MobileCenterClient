using System;
using System.Collections.Generic;
using System.Text;
using MobileCenterClient.Models.MobileCenter;

namespace MobileCenterClient.Models.Exceptions
{
    public class FailedHttpRequestException : MobileCenterApiException
    {
        public string Endpoint { get; }

        public FailedHttpRequestException(string endpoint)
        {
            Endpoint = endpoint;
        }
    }
}
