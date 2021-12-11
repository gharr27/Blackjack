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
        private Player player;

        public GamePage()
        {
            this.InitializeComponent();

            NewGame();           
            player = new Player();

        }

        private async void NewGame()
        {
            Deck deck = await DeckAPIViewModel.NewDeck();

            deck_id = deck.deck_id;
        }

        private async void hitBtn_Click(object sender, RoutedEventArgs e)
        {
            Hand hand = await DeckAPIViewModel.DrawCard(deck_id);

            switch (hand.cards[0].value)
            {
                case "KING": case "QUEEN": case "JACK":
                    player.handValue += 10;
                    break;
                case "ACE":
                    if (player.handValue + 11 <= 21)
                    {
                        player.handValue += 11;
                    }
                    else
                    {
                        player.handValue += 1;
                    }
                    break;
                case "2":
                    player.handValue += 2;
                    break;
                case "3":
                    player.handValue += 3;
                    break;
                case "4":
                    player.handValue += 4;
                    break;
                case "5":
                    player.handValue += 5;
                    break;
                case "6":
                    player.handValue += 6;
                    break;
                case "7":
                    player.handValue += 7;
                    break;
                case "8":
                    player.handValue += 8;
                    break;
                case "9":
                    player.handValue += 9;
                    break;
            }
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
