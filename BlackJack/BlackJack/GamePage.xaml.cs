using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BlackJack.ViewModels;
using BlackJack.Models;
using System.Threading.Tasks;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlackJack
{
    public sealed partial class GamePage : Page
    {
        private string deck_id;

        public GamePage()
        {
            this.InitializeComponent();

            NewGame();           
        }

        private async void NewGame()
        {
            Deck deck = await DeckAPIViewModel.NewDeck();

            deck_id = deck.deck_id;

            //await DeckAPI.Deal(deck_id);
        }

        private async void hitBtn_Click(object sender, RoutedEventArgs e)
        {
            Cards card = await DeckAPIViewModel.DrawCard(deck_id);
            Debug.WriteLine(card.value);

            //if (player.handCount < 5)
            //playerCard<i>.Source = card.image;
            //handValue += card.value
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            //save balance to DB
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void raiseBtn_Click(object sender, RoutedEventArgs e)
        {
            //player.bet += 100;
            //player.balance -= 100;
        }

        private void standBtn_Click(object sender, RoutedEventArgs e)
        {
            //dealer logic
        }
    }
}
