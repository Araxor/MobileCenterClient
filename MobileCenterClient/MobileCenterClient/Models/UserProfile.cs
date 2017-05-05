using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileCenterClient.Models 
{
    public class UserProfile : ObservableObject
    {
        private string _id;
        private string _avatarUrl;
        private bool? _canChangePassword;
        private string _displayName;
        private string _email;
        private string _name;
        private string[] _permissions;

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

        public string AvatarUrl
        {
            get => _avatarUrl;
            set
            {
                if (value == _avatarUrl) return;
                _avatarUrl = value;
                OnPropertyChanged();
            }
        }

        public bool? CanChangePassword
        {
            get => _canChangePassword;
            set
            {
                if (value == _canChangePassword) return;
                _canChangePassword = value;
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

        public string Email
        {
            get => _email;
            set
            {
                if (value == _email) return;
                _email = value;
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

        public string[] Permissions
        {
            get => _permissions;
            set
            {
                if (Equals(value, _permissions)) return;
                _permissions = value;
                OnPropertyChanged();
            }
        }
    }
}
