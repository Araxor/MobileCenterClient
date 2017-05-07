using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MobileCenterClient.ViewModels
{ 
    public class SettingsViewModel : BaseViewModel
    {

        public string ApiToken
        {
            get => Settings.ApiToken;
            set => Settings.ApiToken = value;
        }        
    }
}
