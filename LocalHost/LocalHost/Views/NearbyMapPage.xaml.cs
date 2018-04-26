using System;
using System.Collections.Generic;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class NearbyMapPage : ContentPage
    {
        NearbyMapViewModel viewModel;
        public NearbyMapPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NearbyMapViewModel(this);
        }
    }
}
