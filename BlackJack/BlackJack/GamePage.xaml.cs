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

            Task<Deck> deck = DeckAPIViewModel.NewDeck();

            deck_id = deck.Result.deck_id;
        }

        private void hitButton_Click(object sender, RoutedEventArgs e)
        {
            Task<Card> card = DeckAPIViewModel.DrawCard(deck_id);
            Debug.WriteLine(card.Result.value);
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
