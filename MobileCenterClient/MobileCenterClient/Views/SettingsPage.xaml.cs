using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCenterClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : BasePage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

	    protected override bool OnBackButtonPressed()
	    {
	        Navigation.PopAsync();
	        return base.OnBackButtonPressed();
	    }
    }
}
