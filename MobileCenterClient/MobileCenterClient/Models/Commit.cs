using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.Models
{
    public class Commit : ObservableObject
    {
        private string _message;
        private Author _author;

        public string Message
        {
            get => _message;
            set
            {
                if (value == _message) return;
                _message = value;
                OnPropertyChanged();
            }
        }

        public Author Author
        {
            get { return _author; }
            set { _author = value; }
        }
    }
}
