using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.Models
{
    public class Author : ObservableObject
    {
        private string _name;
        private string _email;
        private DateTime _date;

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

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value == _date) return;
                _date = value;
                OnPropertyChanged();
            }
        }
    }
}
