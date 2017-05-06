using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileCenterClient.Models;
using MobileCenterClient.Models.MobileCenter;
using MobileCenterClient.Views;
using Xamarin.Forms;

namespace MobileCenterClient.ViewModels
{
    public class AppListViewModel : BaseViewModel
    {
        private readonly MobileCenterApi _mobileCenterApi;
        
        public ObservableCollection<Models.App> Apps { get; }

        public ICommand RefreshAppsCommand { get; }

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

        public AppListViewModel()
        {
            _mobileCenterApi = new MobileCenterApi();
            Apps = new ObservableCollection<Models.App>();

            RefreshAppsCommand = new Command(OnRefreshAppsCommand);
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();
            if (Apps.Count == 0)
            {
                await UpdateApps();
            }
        }

        public async void OnRefreshAppsCommand()
        {
            await UpdateApps();
        }

        private async Task UpdateApps()
        {
            Refreshing = true;

            List<Models.App> newApps;
            try
            {
                newApps = await _mobileCenterApi.GetApps();
            }
            catch (MobileCenterApiException e)
            {
                Refreshing = false;
                MessagingCenter.Send(this, Messages.ApiConnectionError);
                return;
            }

            Apps.Clear();
            foreach (var app in newApps)
            {
                Apps.Add(app);
            }

            Refreshing = false;
        }
    }
}
