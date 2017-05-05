using System;
using System.Collections.Generic;
using System.Text;
using MobileCenterClient.ViewModels;
using Xamarin.Forms;

namespace MobileCenterClient.Views
{
    public abstract class BasePage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((BaseViewModel)BindingContext)?.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            ((BaseViewModel)BindingContext)?.OnBackButtonPressed();
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((BaseViewModel)BindingContext)?.OnDisappearing();
        }
    }
}
