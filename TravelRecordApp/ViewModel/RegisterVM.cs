using System;
using System.ComponentModel;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        User user;
        public User User
        {
            get { return User; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

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
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Email");
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
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                ConfirmPassword = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterVM()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Register(User user)
        {
            if (user.Password == user.ConfirmPassword)
            {
                int rows = User.Register(user);
                if (rows > 0)
                {
                    App.Current.MainPage.DisplayAlert("Success", "Registered successfully", "Ok");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Something went wrong", "Ok");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Both password does not match", "Ok");
            }
        }
    }
}
