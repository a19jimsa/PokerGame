using GameCardLib;
using UtilitiesLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private GameManager game;
        public MainWindow()
        {
            InitializeComponent();
            CreatePlayerWindow objectToSubscribeTo = CreatePlayerWindow.Instance;
            objectToSubscribeTo.OnSomethingHappend += HandleSomethingHappening;
            game = new GameManager();
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayerWindow.Instance.Show();
        }
        /// <summary>
        /// Event delegate that fires after an event has happened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSomethingHappening(object sender, EventArgs e)
        {
            //Update dealer and player labels
            deckLabel.Content = "Decks: " + CreatePlayerWindow.Instance.decksBox.Text;
            playersLabel.Content = "Players: " + CreatePlayerWindow.Instance.playersBox.Text;
            int amountOfDecks;
            //Create game deck, a list of cards
            try
            {
                amountOfDecks = Util.ConvertStringToInteger(CreatePlayerWindow.Instance.decksBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Only use integers");
                return;
            }

            //Creates a deck with different amount of decks depending on user input.

            //Create player and dealer with their cards
            int players;
            try
            {
                players = Util.ConvertStringToInteger(CreatePlayerWindow.Instance.playersBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Only use integers");
                return;
            }
            //Enable buttons
            newGameButton.IsEnabled = false;
            HitButton.IsEnabled = true;
            StandButton.IsEnabled = true;
            ShuffleButton.IsEnabled = true;
            game.Players = players;
            game.AmountOfDecks = amountOfDecks;
            if (players > 0 && amountOfDecks > 0)
            {
                bool started = game.Start();
                if (!started)
                {
                    MessageBox.Show("The game could not be started! Input new values.");
                }
                else
                {
                    UpdateDealerGUI();
                    UpdatePlayerGUI();
                }
            }
            else
            {
                MessageBox.Show("Players or decks can't be less or equal to 0");
            }
        }

        /// <summary>
        /// Creates and shows the crete player window form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayerWindow.Instance.Show();
        }
        /// <summary>
        /// Fires when a players clicks the Hit button and is getting a new card to its deck.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            bool isFull = game.Hit();
            if (isFull)
            {
                UpdatePlayerGUI();
                UpdateDealerGUI();
                MessageBox.Show("Sorry, you went over 21!");
                bool isOver = game.UpdatePlayer();
                if (isOver)
                {
                    ShowResults();
                }
            }
            UpdatePlayerGUI();
            UpdateDealerGUI();
        }
        /// <summary>
        /// Shows result of the winners from the round.
        /// </summary>
        private void ShowResults()
        {
            List<Player> winners = game.GetWinners();
            UpdateDealerGUI();
            if(winners.Count == 0)
            {
                MessageBox.Show("Dealer won!");
            }
            foreach (Player player in winners)
            {
                MessageBox.Show("Congratulations to " + player.ToString());
            }
            game.RestartGame();
            UpdatePlayerGUI();
            UpdateDealerGUI();
        }

        /// <summary>
        /// Stand button, when a user decides to stay with its card and wait for opponents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            bool isOver = game.Stand();
            UpdatePlayerGUI();
            UpdateDealerGUI();
            if (isOver)
            {
                ShowResults();
            }
        }

        /// <summary>
        /// Updates the GUI of players cards.
        /// </summary>
        private void UpdatePlayerGUI()
        {
            Player? player = game.GetPlayer();
            canvas1.Children.Clear();
            playerNameLabel.Content = player?.PlayerID;
            playerScoreLabel.Content = "Score: " + Util.ConvertIntToString(player.Score);
            for (int i = 0; i < player?.Hand.NumberOfCards; i++)
            {
                Card card = player.Hand.Cards[i];

                // Create an Image control  
                Image thumbnailImage = new Image();

                // Create a BitmapImage and sets its DecodePixelWidth and DecodePixelHeight  
                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();

                bmpImage.UriSource = card.FilePath;

                thumbnailImage.Height = 200;
                thumbnailImage.Width = 200;
                bmpImage.EndInit();
                // Set Source property of Image  
                thumbnailImage.Source = bmpImage;

                thumbnailImage.Margin = new Thickness(i * 30, 0, 0, 0);

                canvas1.Children.Add(thumbnailImage);
            }
        }

        private void UpdateDealerGUI()
        {
            canvas2.Children.Clear();
            Player? dealer = game.GetDealer();
            dealerScoreLabel.Content = "Score: " + Util.ConvertIntToString(dealer.Score);
            for (int j = 0; j < dealer?.NumberOfCards; j++)
            {
                Card card = dealer.Hand.Cards[j];
                // Create an Image control  
                Image thumbnailImage1 = new Image();
                // Create a BitmapImage and sets its DecodePixelWidth and DecodePixelHeight  
                BitmapImage bmpImage1 = new BitmapImage();
                bmpImage1.BeginInit();
                if (!game.IsDone && j == 1)
                {
                    string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string path = location;
                    Uri baseUri = new Uri(path);
                    bmpImage1.UriSource = new Uri(baseUri, "../../../Assets/BACK.png");
                    dealerScoreLabel.Content = "Score: " + ((dealer.Hand.Score - (int)dealer.Hand.Cards[j].Value));
                }
                else
                {
                    bmpImage1.UriSource = card.FilePath;
                }
                thumbnailImage1.Height = 200;
                thumbnailImage1.Width = 200;
                bmpImage1.EndInit();
                // Set Source property of Image  
                thumbnailImage1.Source = bmpImage1;
                thumbnailImage1.Margin = new Thickness(j * 30, 0, 0, 0);
                canvas2.Children.Add(thumbnailImage1);
            }
        }
        /// <summary>
        /// When a user clicks the Shuffle button it reshuffles the deck.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            //PlayerManager delegate do something when clicked
            game.Reshuffle();
            MessageBox.Show("The card deck has been reshuffled!");
        }
    }
}