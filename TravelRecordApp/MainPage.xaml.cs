using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainVM ViewModel;
        public MainPage()
        {
            InitializeComponent();

            ViewModel = new MainVM();
            BindingContext = ViewModel;

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.dicee_logo.png", assembly);
        }
    }
}
