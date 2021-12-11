using BlackJack.Models;
using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlackJack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public SignInPage()
        {
            this.InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            //add and save new User to DB
            using (var db = new UserDB())
            {
                
            }
            this.Frame.Navigate(typeof(GamePage));
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            //search and find User in DB
            using (var db = new UserDB())
            {
                var newUser = new UserViewModel
                {
                    Username = signUpEntry.Text,
                    Balance = 5000,
                    Blackjacks = 0
                };

                db.Users.Add();
                db.SaveChanges();
            }
            this.Frame.Navigate(typeof(GamePage));
        }
    }
}
