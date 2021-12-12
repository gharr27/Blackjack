using BlackJack.Models;
using BlackJack.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        public UserViewModel User { get; set; }
        public LeaderboardViewModel Leaderboard { get; set; }

        public SignInPage()
        {
            this.InitializeComponent();

            User = new UserViewModel();
            Leaderboard = new LeaderboardViewModel();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            //add and save new User to DB

            var newUser = new UserViewModel
            {
                Username = signInEntry.Text,
                Balance = 0,
                Blackjacks = 0
            };

            Leaderboard.Users.Add(newUser);

            string json = JsonConvert.SerializeObject(newUser);
            ApplicationData.Current.LocalSettings.Values["user"] = json;


            //send username and db data to GamePage?
            this.Frame.Navigate(typeof(GamePage));
        }
    }
}
