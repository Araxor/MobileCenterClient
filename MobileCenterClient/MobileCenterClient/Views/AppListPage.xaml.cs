﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCenterClient.ViewModels;
using Xamarin.Forms;

namespace MobileCenterClient.Views
{
	public partial class AppListPage : BasePage
	{
		public AppListPage()
		{
			InitializeComponent();
            
            // Disable selection on AppsListView items
		    AppsListView.ItemSelected += (sender, args) => 
                ((ListView) sender).SelectedItem = null;

            // Navigate to branch list view on tapped item
            AppsListView.ItemTapped += async (sender, args) =>
		        await Navigation.PushAsync(new BranchListPage((Models.App) args.Item));
		}
	}
}
