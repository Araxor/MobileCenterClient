using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        public virtual void OnAppearing() { }
        public virtual void OnDisappearing() { }
        public virtual void OnBackButtonPressed() { }

    }
}
