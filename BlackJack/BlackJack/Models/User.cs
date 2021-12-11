using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class User
    {
        public int Id { get; set; }

        private string username { get; set; }

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
        private int balance { get; set; }
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

        private int blackjacks { get; set; }
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
