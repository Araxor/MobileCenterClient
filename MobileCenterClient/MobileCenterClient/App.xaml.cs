using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace MobileCenterClient
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new MobileCenterClient.Views.AppListPage();
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
		    MobileCenter.Start("android="+Secrets.MobileCenterAndroidSecret+";" +
                               "ios="+Secrets.MobileCenterIOsSecret,
		                       typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
