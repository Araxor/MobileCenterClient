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
        public MobileCenterApi Api { get; }
        public Models.App App { get; }

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

        public string PageTitle => $"{App.Name} branches";

        public BranchListViewModel(Models.App app)
        {
            Api = new MobileCenterApi();
            Branches = new ObservableCollection<Models.BranchStatus>();
            App = app;

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
                newBranches = await Api.GetBranches(App.Owner.Name, App.Name);
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
