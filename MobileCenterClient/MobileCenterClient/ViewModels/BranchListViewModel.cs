using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileCenterClient.Models;
using MobileCenterClient.Models.MobileCenter;
using Xamarin.Forms;

namespace MobileCenterClient.ViewModels
{
    public class BranchListViewModel : BaseViewModel
    {
        private readonly MobileCenterApi _mobileCenterApi;
        private readonly Models.App _app;
        
        public ObservableCollection<Models.BranchStatus> Branches { get; }
        public ICommand RefreshBranchesCommand { get; }

        private bool _refreshing = false;
        public bool Refreshing
        {
            get => _refreshing;
            private set
            {
                if (value == _refreshing) return;
                _refreshing = value;
                OnPropertyChanged();
            }
        }

        public BranchListViewModel(Models.App app)
        {
            _mobileCenterApi = new MobileCenterApi();
            Branches = new ObservableCollection<Models.BranchStatus>();
            _app = app;

            RefreshBranchesCommand = new Command(async () => await UpdateBranches());
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();
            await UpdateBranches();
        }

        private async Task UpdateBranches()
        {
            Refreshing = true;

            List<BranchStatus> newBranches;
            try
            {
                newBranches = await _mobileCenterApi.GetBranches(_app.Owner.Name, _app.Name);
            }
            catch (MobileCenterApiException e)
            {
                MessagingCenter.Send(this, Messages.ApiConnectionError);
                Refreshing = false;
                return;
            }

            Branches.Clear();
            foreach (var branch in newBranches)
            {
                Branches.Add(branch);
            }

            Refreshing = false;
        }
    }
}
