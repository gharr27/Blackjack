using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class LeaderboardViewModel
    {
        public Leaderboard leaderboard;

        public ObservableCollection<UserViewModel> Users { get; set;  }

        public LeaderboardViewModel()
        {
            leaderboard = new Leaderboard();

            Users = new ObservableCollection<UserViewModel>();

            foreach(var user in leaderboard.UserList)
            {
                Users.Add(new UserViewModel(user));
            }

            Users.CollectionChanged += Users_CollectionChanged;
        }

        public void UpdateUser(int index, int balance, int blackJacks)
        {
            var userViewModel = Users.ElementAt(index - 1);
            userViewModel.Balance = balance;
            userViewModel.Blackjacks = blackJacks;
            leaderboard.UpdateUser(userViewModel.Model);
        }

        private void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var userViewModel = e.NewItems[0] as UserViewModel;
                leaderboard.AddUser(userViewModel.Model);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                // Replace Action is not being triggered when items in list are replaced
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var userViewModel = e.OldItems[0] as UserViewModel;
                leaderboard.DeleteUser(userViewModel.Model);
            }
        }

    }
}
