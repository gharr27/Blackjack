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
        private Dealer dealer;
        private int bet_value;

        private bool standing = false;
        private bool dealerStanding = false;

        private Uri imageUri;
        private BitmapImage bitmapImage;

        public GamePage()
        {
            this.InitializeComponent();

            player = new Player();
            dealer = new Dealer();
            player.balance = 2500;
            NewGame();           
        }

        private void CheckForEndGame()
        {
            if(player.handValue == 21 || dealer.handValue == 21)
            {
                if (player.handValue == 21) //Player Wins
                {
                    player.balance += bet_value * 2;
                    NewGame();
                }
                else //Dealer Wins
                {
                    NewGame();
                }
            }
            if(player.handValue > dealer.handValue && standing || dealerStanding) //Player Wins
            {
                player.balance += bet_value * 2;
                NewGame();
            }
            else //Dealer Wins
            {
                NewGame();
            }
            if(player.handValue > 21)//Dealer Wins
            {
                NewGame();
            }
            else if (dealer.handValue > 21)//Player Wins
            {
                player.balance += bet_value * 2;
                NewGame();
            }
        }

        private async void NewGame()
        {
            standing = false;
            dealerStanding = false;

            player.handValue = 0;
            player.handCount = 0;

            dealer.handValue = 0;
            dealer.handCount = 0;

            bet_value = 0;

            playerHand.Text = "Hand: 0";
            playerBalance.Text = "Balance: $" + player.balance;
            playerBet.Text = "Bet: $" + bet_value;

            playerCard1.Source = null;
            playerCard2.Source = null;
            playerCard3.Source = null;
            playerCard4.Source = null;
            playerCard5.Source = null;

            Deck deck = await DeckAPIViewModel.NewDeck();

            deck_id = deck.deck_id;

            Deck hand = await DeckAPIViewModel.Deal(deck_id);

            player.handCount = 2;
            dealer.handCount = 2;

            imageUri = new Uri(hand.cards[0].image, UriKind.Absolute);
            bitmapImage = new BitmapImage(imageUri);
            playerCard1.Source = bitmapImage;

            imageUri = new Uri(hand.cards[2].image, UriKind.Absolute);
            bitmapImage = new BitmapImage(imageUri);
            playerCard2.Source = bitmapImage;

            imageUri = new Uri(hand.cards[3].image, UriKind.Absolute);
            bitmapImage = new BitmapImage(imageUri);
            dealerCard2.Source = bitmapImage;

            AddCardValue(hand.cards[0].value);
            AddCardValue(hand.cards[2].value);

            AddDealerCardValue(hand.cards[1].value);
            AddDealerCardValue(hand.cards[3].value);
        }

        private async void hitBtn_Click(object sender, RoutedEventArgs e)
        {
            player.handCount++;
            if (player.handCount <= 5)
            {
                Hand hand = await DeckAPIViewModel.DrawCard(deck_id);

                switch (player.handCount)
                {
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

                AddCardValue(hand.cards[0].value);
            }
            CheckForEndGame();
            DealerMove();
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            //save balance to DB
            this.Frame.Navigate(typeof(MenuPage));
        }

        private void raiseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (player.balance > 100)
            {
                bet_value += 100;
                player.balance -= 100;
            }
            else
            {
                bet_value += player.balance;
                player.balance -= player.balance;
            }

            playerBalance.Text = "Balance: $" + player.balance;
            playerBet.Text = "Bet: $" + bet_value;
        }

        private void standBtn_Click(object sender, RoutedEventArgs e)
        {
            standing = true;
        }

        private void AddCardValue(string value)
        {
            switch (value)
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

        private void AddDealerCardValue(string value)
        {
            switch (value)
            {
                case "KING":
                case "QUEEN":
                case "JACK":
                case "10":
                    dealer.handValue += 10;
                    break;
                case "ACE":
                    if (dealer.handValue + 11 <= 21)
                    {
                        dealer.handValue += 11;
                    }
                    else
                    {
                        dealer.handValue += 1;
                    }
                    break;
                case "2":
                    dealer.handValue += 2;
                    break;
                case "3":
                    dealer.handValue += 3;
                    break;
                case "4":
                    dealer.handValue += 4;
                    break;
                case "5":
                    dealer.handValue += 5;
                    break;
                case "6":
                    dealer.handValue += 6;
                    break;
                case "7":
                    dealer.handValue += 7;
                    break;
                case "8":
                    dealer.handValue += 8;
                    break;
                case "9":
                    dealer.handValue += 9;
                    break;
            }
        }

        private async void DealerMove()
        {
            if(dealer.isMakeMove())
            {
                dealer.handCount++;
                if (dealer.handCount <= 5)
                {
                    Hand hand = await DeckAPIViewModel.DrawCard(deck_id);

                    AddDealerCardValue(hand.cards[0].value);
                    //AddDealerCardImage(dealer.handCount);
                }
                CheckForEndGame();
            }
            else
            {
                dealerStanding = true;
            }
        }

        private void AddDealerCardImage(int count)
        {

            switch (count)
            {
                case 3:
                    
                    dealerCard3.Source = bitmapImage;
                    break;
                case 4:
                    imageUri = new Uri("Assets/CardBack.png", UriKind.RelativeOrAbsolute);
                    bitmapImage = new BitmapImage(imageUri);
                    dealerCard4.Source = bitmapImage;
                    break;
                case 5:
                    imageUri = new Uri("Assets/CardBack.png", UriKind.RelativeOrAbsolute);
                    bitmapImage = new BitmapImage(imageUri);
                    dealerCard5.Source = bitmapImage;
                    break;
            }
        }

        private void redrawBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
