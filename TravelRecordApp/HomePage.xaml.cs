using System;
using System.Collections.Generic;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;
        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomeVM();
            BindingContext = viewModel;
        }
    }
}
