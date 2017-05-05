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
        public List<Models.App> Apps { get; }

        public AppListViewModel()
        {
            _mobileCenterApi = new MobileCenterApi();
            Apps = new List<Models.App>();
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            var newApps = await _mobileCenterApi.GetApps();
            Apps.Clear();
            Apps.AddRange(newApps);
        }

        private async Task<List<Models.App>> LoadApps()
        {
            return await _mobileCenterApi.GetApps();
        }
    }
}
