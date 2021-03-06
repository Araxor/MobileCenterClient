﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCenterClient.ExtensionMethods;
using MobileCenterClient.ViewModels;
using Xamarin.Forms;

namespace MobileCenterClient.Views
{
	public partial class AppListPage : BasePage
	{
	    private Dictionary<Models.App, Page> PagesPerApp { get; } = new Dictionary<Models.App, Page>();

        public AppListPage()
		{
			InitializeComponent();
            
            // Disable selection on AppsListView items
		    AppsListView.ItemSelected += (sender, args) => 
                ((ListView) sender).SelectedItem = null;

            // Navigate to branch list view on tapped item
		    AppsListView.ItemTapped += OnItemTapped;

            // 
            SettingsToolbarItem.Clicked += OnSettingsToolbarItemClicked;

            // Subscribe to connection error message from the viewModel
            MessagingCenter.Subscribe<AppListViewModel>(this, Messages.ApiConnectionError, OnApiConnectionError);
		}

        private async void OnSettingsToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
	    {
	        var page = PagesPerApp.GetOrCreate((Models.App) args.Item, () => new BranchListPage((Models.App) args.Item));

            await Navigation.PushAsync(page);
        }

        private async void OnApiConnectionError(AppListViewModel viewModel)
	    {
	        if (await DisplayAlert("Connection error", "Cannot connect to Mobile Center API.", "Configure key", "Cancel"))
	        {
	            await Navigation.PushAsync(new SettingsPage());
	        }
        }
	}
}
