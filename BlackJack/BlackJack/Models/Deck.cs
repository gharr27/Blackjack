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
        public Cards[] cards { get; set; }
    }

    public class Cards
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }
}
