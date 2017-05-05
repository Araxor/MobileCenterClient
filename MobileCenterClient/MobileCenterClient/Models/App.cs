using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileCenterClient.Models
{
    public class App : ObservableObject
    {
        private string _id;
        private string _appSecret;
        private string _azureSubscriptionId;
        private string _description;
        private string _displayName;
        private string _iconUrl;
        private string _name;
        private List<string> _memberPermissions;
        private string _os;
        private AppOwner _appOwner;

        public string Id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string AppSecret
        {
            get => _appSecret;
            set
            {
                if (value == _appSecret) return;
                _appSecret = value;
                OnPropertyChanged();
            }
        }

        public string AzureSubscriptionId
        {
            get => _azureSubscriptionId;
            set
            {
                if (value == _azureSubscriptionId) return;
                _azureSubscriptionId = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (value == _appSecret) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public string DisplayName
        {
            get => _displayName;
            set
            {
                if (value == _displayName) return;
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public string IconUrl
        {
            get => _iconUrl;
            set
            {
                if (value == _iconUrl) return;
                _iconUrl = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public List<string> MemberPermissions
        {
            get => _memberPermissions;
            set
            {
                if (value == _memberPermissions) return;
                _memberPermissions = value;
                OnPropertyChanged();
            }
        }

        public string Os
        {
            get => _os;
            set
            {
                if (value == _os) return;
                _os = value;
                OnPropertyChanged();
            }
        }

        public AppOwner AppOwner
        {
            get => _appOwner;
            set
            {
                if (value == _appOwner) return;
                _appOwner = value;
                OnPropertyChanged();
            }
        }
    }
}
