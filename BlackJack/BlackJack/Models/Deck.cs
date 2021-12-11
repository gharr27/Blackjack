using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BlackJack.Models
{
    public class Deck
    {
        private bool success { get; set; }
        public string deck_id { get; set; }
        private bool shuffled { get; set; }
        private int remaining { get; set; }
        public Card[] cards { get; set; }
    }

    public class Hand
    { 
        bool success { get; set; }
        public List<Card> cards { get; set; }
        string deck_id { get; set; }
        int remaining { get; set; }
    }

    public class Card
    {
        
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }
}
