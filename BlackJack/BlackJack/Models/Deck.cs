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
        private string deck_id { get; set; }
        private int remaining { get; set; }
        private bool shuffled { get; set; }
        public List<Card> Hand { get; set; }
    }

    public class Card
    {
        private string image { get; set; }
        private string value { get; set; }
        private string suit { get; set; }
        private string code { get; set; }
    }
}
