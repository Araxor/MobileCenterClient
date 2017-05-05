using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileCenterClient.Models;
using Xamarin.Forms;

namespace MobileCenterClient.ViewModels
{
    public class BranchListViewModel : BaseViewModel
    {
        private readonly MobileCenterApi _mobileCenterApi;
        private readonly Models.App _app;
        
        public ObservableCollection<Models.BranchStatus> Branches { get; }

        public ICommand ViewAppCommand { get; } = new Command(() => {});

        public BranchListViewModel(Models.App app)
        {
            _mobileCenterApi = new MobileCenterApi();
            Branches = new ObservableCollection<Models.BranchStatus>();
            _app = app;
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

           await UpdateBranches();
        }

        private async Task UpdateBranches()
        {
            var newBranches = await _mobileCenterApi.GetBranches(_app.Owner.Name, _app.Name);
            Branches.Clear();
            foreach (var branch in newBranches)
            {
                Branches.Add(branch);
            }
        }
    }
}
