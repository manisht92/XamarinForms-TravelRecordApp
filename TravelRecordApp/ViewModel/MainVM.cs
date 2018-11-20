using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public LoginCommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged(Email);
            }
        }

        string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged(Password);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            bool canLogin = User.Login(User.Email, User.Password);

            if (!canLogin)
            {
                App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }
    }
}
