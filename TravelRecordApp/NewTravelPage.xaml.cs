using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var selectedValue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedValue.categories.FirstOrDefault();
                Post post = new Post()
                {
                    Experience = experienceEntry.Text,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = selectedValue.location.address,
                    Distance = selectedValue.location.distance,
                    Latitude = selectedValue.location.lat,
                    Longitude = selectedValue.location.lng,
                    VanueName = selectedValue.name

                };
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);
                    if (rows > 0)
                        DisplayAlert("Success", "Experience successfully inserted", "Ok");
                    else
                        DisplayAlert("Error", "Experience failed to be inserted", "Ok");
                }
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
