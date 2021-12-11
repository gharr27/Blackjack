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
using Windows.UI.Xaml.Media.Imaging;

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
        }

        private void CheckForEndGame()
        {
            if(player.handValue == 21) //Player win
            {
                NewGame();
            }
            else if (player.handValue > 21) // Player lose
            {
                NewGame();
            }
        }

        private async void NewGame()
        {
            Deck deck = await DeckAPIViewModel.NewDeck();
            player = new Player();
            playerHand.Text = "Hand: 0";

            playerCard1.Source = null;
            playerCard2.Source = null;
            playerCard3.Source = null;
            playerCard4.Source = null;
            playerCard5.Source = null;


            deck_id = deck.deck_id;
        }

        private async void hitBtn_Click(object sender, RoutedEventArgs e)
        {
            player.handCount++;
            if (player.handCount <= 5)
            {
                Hand hand = await DeckAPIViewModel.DrawCard(deck_id);
                Uri imageUri;
                BitmapImage bitmapImage;

                switch (player.handCount)
                {
                    case 1:
                        imageUri = new Uri(hand.cards[0].image, UriKind.Absolute);
                        bitmapImage = new BitmapImage(imageUri);
                        playerCard1.Source = bitmapImage;
                        break;
                    case 2:
                        imageUri = new Uri(hand.cards[0].image, UriKind.Absolute);
                        bitmapImage = new BitmapImage(imageUri);
                        playerCard2.Source = bitmapImage;
                        break;
                    case 3:
                        imageUri = new Uri(hand.cards[0].image, UriKind.Absolute);
                        bitmapImage = new BitmapImage(imageUri);
                        playerCard3.Source = bitmapImage;
                        break;
                    case 4:
                        imageUri = new Uri(hand.cards[0].image, UriKind.Absolute);
                        bitmapImage = new BitmapImage(imageUri);
                        playerCard4.Source = bitmapImage;
                        break;
                    case 5:
                        imageUri = new Uri(hand.cards[0].image, UriKind.Absolute);
                        bitmapImage = new BitmapImage(imageUri);
                        playerCard5.Source = bitmapImage;
                        break;
                }

                switch (hand.cards[0].value)
                {
                    case "KING":
                    case "QUEEN":
                    case "JACK":
                    case "10":
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
                playerHand.Text = "Hand: " + player.handValue;
            }
            CheckForEndGame();
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
