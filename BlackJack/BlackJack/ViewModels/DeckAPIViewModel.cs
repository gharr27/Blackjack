using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    class DeckAPIViewModel
    {
        public async static Task<Deck> NewDeck()
        {
            Deck deck = await DeckAPI.NewDeck();
            return deck;
        }

        public async static Task<Deck> Deal(string deck_id)
        {
            return await DeckAPI.Deal(deck_id);
        }

        public async static Task<Hand> DrawCard(string deck_id)
        {
            return await DeckAPI.DrawCard(deck_id);
        }
    }
}
