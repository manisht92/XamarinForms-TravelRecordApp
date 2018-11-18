using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.dicee_logo.png", assembly);
        }

        void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            bool canLogin = User.Login(emailEntry.Text, passwordEntry.Text);

            if (!canLogin)
            {
                DisplayAlert("Error", "Try again", "Ok");
            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
