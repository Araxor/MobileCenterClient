using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileCenterClient.Models
{
    public class CommitDetails : ObservableObject
    {
        private string _sha;
        private string _url;
        private Commit _commit;

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

        public Commit Commit
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
