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
        private string username;
        private int balance;
        private int blackjacks;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Balance"));
            }
        }

        public int Blackjacks
        {
            get
            {
                return blackjacks;
            }
            set
            {
                blackjacks = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Blackjacks"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
    }
}
