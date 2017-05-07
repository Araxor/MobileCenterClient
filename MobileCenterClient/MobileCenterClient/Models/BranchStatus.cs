using System;
using System.Collections.Generic;
using System.Text;
using MobileCenterClient.ExtensionMethods;
using Newtonsoft.Json;

namespace MobileCenterClient.Models
{
    public class BranchStatus : ObservableObject
    {
        private Branch _branch;
        private bool _configured;
        private Build _lastBuild;
        private string _trigger;

        public BranchStatus() {}

        public Branch Branch
        {
            get => _branch;
            set
            {
                if (value == _branch) return;
                _branch = value;
                OnPropertyChanged();
            }
        }

        public bool Configured
        {
            get => _configured;
            set
            {
                if (value == _configured) return;
                _configured = value;
                OnPropertyChanged();
            }
        }

        public Build LastBuild
        {
            get => _lastBuild;
            set 
            {
                if (value == _lastBuild) return;
                _lastBuild = value;
                OnPropertyChanged();
            }
        }

        public string Trigger
        {
            get => _trigger;
            set
            {
                if (value == _trigger)
                _trigger = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get
            {
                if (!Configured) return "Not configured";
                return LastBuild.Status.FirstCharToUpper();
            }
        }
    }
}
