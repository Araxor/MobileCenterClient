using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileCenterClient.Models
{
    public class AppOwner : ObservableObject
    {
        private string _id;
        private string _avatarUrl;
        private string _displayName;
        private string _email;
        private string _name;
        private string _type;

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

        public string Type
        {
            get => _type;
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged();
            }
        }
    }
}