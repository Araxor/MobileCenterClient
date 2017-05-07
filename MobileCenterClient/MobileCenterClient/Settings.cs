using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MobileCenterClient
{
    static class Settings
    {
        public static readonly string ApiTokenKey = "API_TOKEN";

        private static ISettings AppSettings => CrossSettings.Current;

        public static string ApiToken
        {
            get => AppSettings.GetValueOrDefault<string>(ApiTokenKey, "");
            set => AppSettings.AddOrUpdateValue<string>(ApiTokenKey, value);
        }
    }
}
