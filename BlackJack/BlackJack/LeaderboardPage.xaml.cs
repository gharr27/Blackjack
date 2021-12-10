using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class LeaderboardPage : Page
    {
        private ObservableCollection<User> leaderboard;

        public LeaderboardPage()
        {
            this.InitializeComponent();

            using (var db = new UserDB())
            {
                leaderboard = new ObservableCollection<User>();
                foreach (var user in db.Users)
                {
                    leaderboard.Add(user);
                }
            }
        }

        private void menuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
