using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.Models
{
    public class Build : ObservableObject
    {
        private int _id;
        private string _buildNumber;
        private DateTime _queueTime;
        private DateTime _startTime;
        private DateTime _finishTime;
        private DateTime _lastChangedDate;
        private string _status;
        private string _result;
        private string _sourceBranch;
        private string _sourceVersion;

        public int Id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string BuildNumber
        {
            get => _buildNumber;
            set
            {
                if (value == _buildNumber) return; 
                _buildNumber = value;
                OnPropertyChanged();
            }
        }

        public DateTime QueueTime
        {
            get => _queueTime;
            set
            {
                if (value == _queueTime) return;
                _queueTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (value == _startTime) return;
                _startTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime FinishTime
        {
            get => _finishTime;
            set
            {
                if (value == _finishTime) return;
                _finishTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastChangedDate
        {
            get => _lastChangedDate;
            set
            {
                if (value == _lastChangedDate) return;
                _lastChangedDate = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (value == _status) return;
                _status = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                if (value == _result) return;
                _result = value;
                OnPropertyChanged();
            }
        }

        public string SourceBranch
        {
            get => _sourceBranch;
            set
            {
                if (value == _sourceBranch) return;
                _sourceBranch = value;
                OnPropertyChanged();
            }
        }

        public string SourceVersion
        {
            get => _sourceVersion;
            set
            {
                if (value == _sourceVersion) return;
                _sourceVersion = value;
                OnPropertyChanged();
            }
        }
    }
}
