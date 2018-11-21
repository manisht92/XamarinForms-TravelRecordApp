using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        //User user;
        RegisterVM ViewModel;
        public RegisterPage()
        {
            InitializeComponent();
            //user = new User();
            //containerStackLayout.BindingContext = user;
            ViewModel = new RegisterVM();
            BindingContext = ViewModel;
        }
    }
}
