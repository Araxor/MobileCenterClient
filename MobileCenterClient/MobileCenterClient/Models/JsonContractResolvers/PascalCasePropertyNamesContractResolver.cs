using System;
using MobileCenterClient.ExtensionMethods;
using Newtonsoft.Json.Serialization;


namespace MobileCenterClient.Models
{
    public class PascalCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.FirstCharToLower();
        }
    }
}
