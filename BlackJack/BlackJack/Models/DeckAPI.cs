﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            Uri request = new Uri($"{baseUrl}/{deck_id}/draw/?count=4");

            Deck hand;

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(request);
                hand = JsonConvert.DeserializeObject<Deck>(json);
            }

            return hand;
        }

        public async static Task<Hand> DrawCard(string deck_id)
        {
            Uri request = new Uri($"{baseUrl}/{deck_id}/draw/?count=1");

            Hand hand;

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(request);
                hand = JsonConvert.DeserializeObject<Hand>(json);
            }

            return hand;
        }
    }
}
