using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MobileCenterClient.Models;
using Xamarin.Forms;

namespace MobileCenterClient.ViewModels
{
    public class AppListViewModel : BaseViewModel
    {
        private readonly MobileCenterApi _mobileCenterApi;
        public ObservableCollection<Models.App> Apps { get; }

        public AppListViewModel()
        {
            _mobileCenterApi = new MobileCenterApi();
            Apps = new ObservableCollection<Models.App>();
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            await UpdateApps();
        }

        private async Task UpdateApps()
        {
            var newApps = await _mobileCenterApi.GetApps();
            Apps.Clear();
            foreach (var app in newApps)
            {
                Apps.Add(app);
            }
        }
    }
}
