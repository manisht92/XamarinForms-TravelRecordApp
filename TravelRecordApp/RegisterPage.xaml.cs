using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        User user;
        public RegisterPage()
        {
            InitializeComponent();
            user = new User();
            containerStackLayout.BindingContext = user;
        }

        void RegisterButton_Clicked(object sender, System.EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                int rows = User.Register(user);
                if (rows > 0)
                {
                    DisplayAlert("Success", "Registered successfully", "Ok");
                }
                else
                {
                    DisplayAlert("Alert", "Something went wrong", "Ok");
                }
            }
            else
            {
                DisplayAlert("Alert", "Both password does not match", "Ok");
            }
        }
    }
}
