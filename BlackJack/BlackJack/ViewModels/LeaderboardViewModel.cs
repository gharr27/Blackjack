using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    class LeaderboardViewModel
    {
        private Leaderboard leaderboard;

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


    }
}
