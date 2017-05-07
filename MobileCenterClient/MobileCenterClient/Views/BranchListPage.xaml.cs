using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCenterClient.ViewModels;
using Xamarin.Forms;

namespace MobileCenterClient.Views
{
	public partial class BranchListPage : BasePage
	{
		public BranchListPage(Models.App app)
		{
			InitializeComponent();
            
            // Disable selection on BranchListView items
		    BranchListView.ItemSelected += (sender, args) => ((ListView) sender).SelectedItem = null;

		    BindingContext = new BranchListViewModel(app);

	        // Subscribe to connection error message from the viewModel
	        MessagingCenter.Subscribe<BranchListViewModel>(this, Messages.ApiConnectionError, OnApiConnectionError);
	    }

	    private async void OnApiConnectionError(BranchListViewModel viewModel)
	    {
	        if (await DisplayAlert("Connection error", "Cannot connect to Mobile Center API.", "Configure key", "Cancel"))
	        {
	            Navigation.PushAsync(new SettingsPage())
	        }
	    }

        protected override bool OnBackButtonPressed()
	    {
	        Navigation.PopAsync();
	        return base.OnBackButtonPressed();
	    }
	}
}
