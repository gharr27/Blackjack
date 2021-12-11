using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private User user;

        public UserViewModel(User user = null)
        {
            if(user == null)
            {
                user = new User();
            }

            this.user = user;
        }

        public User Model
        {
            get
            {
                return user;
            }
        }

        public int UserId
        {
            get { return user.Id; }
            set { user.Id = value; }
        }

        public string Username
        {
            get
            {
                return user.Username;
            }
            set
            {
                user.Username = value;
                OnPropertyChanged("Username");
            }
        }

        public int Balance
        {
            get
            {
                return user.Balance;
            }
            set
            {
                user.Balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public int Blackjacks
        {
            get
            {
                return user.Blackjacks;
            }
            set
            {
                user.Blackjacks = value;
                OnPropertyChanged("Blackjacks");
            }
        }

        
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
