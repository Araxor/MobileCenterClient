using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;

namespace MobileCenterClient.Models
{
    /// <summary>
    /// Contract resolver for Newtonsoft.Json that maps snake_case property names to PascalCase names.
    /// Inspired from http://www.raph.ws/2014/12/json-serialisationdeserialisation-with.html
    /// </summary>
    class SnakeCasePropertyNamesContractResolver : DefaultContractResolver
    {
        Regex startUnderscoresRegex = new Regex(@"^_+");
        Regex capitalsRegex = new Regex(@"([A-Z])");

        protected override string ResolvePropertyName(string propertyName)
        {
            var startUnderscores = startUnderscoresRegex.Match(propertyName);
            return startUnderscores + capitalsRegex.Replace(propertyName, "_$1")
                                                   .ToLower()
                                                   .TrimStart('_');
        }
    }
}
