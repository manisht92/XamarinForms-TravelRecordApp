using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.ComponentModel;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(id);
            }
        }

        private string experience;
        [MaxLength(250)]
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged(experience);
            }
        }

        private string vanue_name;
        public string VanueName
        {
            get { return vanue_name; }
            set
            {
                vanue_name = value;
                OnPropertyChanged(vanue_name);
            }
        }

        private string category_id;
        public string CategoryId
        {
            get { return category_id; }
            set
            {
                category_id = value;
                OnPropertyChanged(category_id);
            }
        }

        private string category_name;
        public string CategoryName
        {
            get { return category_name; }
            set
            {
                category_name = value;
                OnPropertyChanged(category_name);
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(address);
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged(latitude);
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged(longitude);
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged(distance);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(int propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName.ToString()));
        }

        private void OnPropertyChanged(double propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName.ToString()));
        }

        public static int Insert(Post post)
        {
            int rows = 0;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                rows = conn.Insert(post);
            }
            return rows;
        }

        public static List<Post> Read()
        {
            List<Post> posts;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                posts = conn.Table<Post>().ToList();
            }
            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                var count = (from post in posts
                             where post.CategoryName == category
                             select post).ToList().Count;
                categoriesCount.Add(category, count);
            }
            return categoriesCount;
        }
    }
}