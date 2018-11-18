using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        Post post;
        public NewTravelPage()
        {
            InitializeComponent();
            post = new Post();
            containerStackLayout.BindingContext = post;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var selectedValue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedValue.categories.FirstOrDefault();

                post.CategoryId = firstCategory.id;
                post.CategoryName = firstCategory.name;
                post.Address = selectedValue.location.address;
                post.Distance = selectedValue.location.distance;
                post.Latitude = selectedValue.location.lat;
                post.Longitude = selectedValue.location.lng;
                post.VanueName = selectedValue.name;

                int rows = Post.Insert(post);
                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully inserted", "Ok");
                else
                    DisplayAlert("Error", "Experience failed to be inserted", "Ok");
            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}
