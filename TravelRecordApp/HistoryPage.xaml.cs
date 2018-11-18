using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;

using Xamarin.Forms;
using TravelRecordApp.Model;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            postListView.ItemsSource = Post.Read();
        }
    }
}
