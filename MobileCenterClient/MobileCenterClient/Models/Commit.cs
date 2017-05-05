using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.Models
{
    public class Commit : ObservableObject
    {
        private string _sha;
        private string _url;

        public string Sha
        {
            get => _sha;
            set
            {
                if (value == _sha) return;
                _sha = value;
                OnPropertyChanged();
            }
        }

        public string Url
        {
            get => _url;
            set
            {
                if (value == _url) return;
                _url = value;
                OnPropertyChanged();
            }
        }
    }
}
