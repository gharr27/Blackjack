using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class DeckAPI
    {
        private const string baseUrl = "https://deckofcardsapi.com/api/deck";

        public async static Task<Deck> NewDeck()
        {
            Uri request = new Uri($"{baseUrl}/new/shuffle/");
            Deck deck;

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(request);
                deck = JsonConvert.DeserializeObject<Deck>(json);
            }

            return deck;
        }

        public async static Task<Deck> Deal(string deck_id)
        {
            Uri request = new Uri($"{baseUrl}/{deck_id}/draw/?count=2");

            Card[] cards;

            for(int i = 0; i < 2; i++)
            {

            }


        }
    }
}
