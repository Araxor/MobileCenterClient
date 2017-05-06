using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.Models
{
    public class Branch : ObservableObject
    {
        private string _name;
        private CommitDetails _commit;

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

        public CommitDetails Commit
        {
            get => _commit;
            set
            {
                if (value == _commit) return; 
                _commit = value;
                OnPropertyChanged();
            }
        }
    }
}
