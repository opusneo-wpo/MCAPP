﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsPinViewSample.ViewModels;

namespace FormsPinViewSample.Views
{
    public partial class PinAuthPage : ContentPage
    {
        public PinAuthPage()
        {
 
            InitializeComponent();

            var vm = new PinAuthViewModel();
            
            vm.PinViewModel.OnSuccess += (sender, e) =>
            {
                Navigation.PopAsync();
            };

            BindingContext = vm;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}

