using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameCardLib
{
    sealed public class GameManager
    {
        private PlayerManager<Player> playerManager;
        private List<Card> cardDeck;
        private List<Card> discardCardDeck;
        private int activePlayerIndex = 0;
        public int AmountOfDecks { get; set; }
        public int Players { get; set; }
        public bool IsDone = false;

        public GameManager()
        {
            playerManager = new PlayerManager<Player>();
            discardCardDeck = new List<Card>();
        }

        public bool Start()
        {
            // Create a new deck
            cardDeck = new List<Card>();
            CreateDeck();
            Reshuffle();

            //ADD a dealer to the playerManager list
            Player dealer = new Player("0", "Dealer", new Hand(new Deck(cardDeck)), false);
            playerManager.Add(dealer);

            //ADD rest of the players to the playerManager list
            for (var i = 0; i < Players; i++)
            {
                Player player = new Player("Player " + i, "Player", new Hand(new Deck(cardDeck)), false);
                playerManager.Add(player);
            }

            //Check if their is enough players to start a game.
            if ((Players * 2) + AmountOfDecks < AmountOfDecks * 52)
            {
                activePlayerIndex = playerManager.List.FindIndex(p => p.Name.Contains("Player"));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adding cards to the deck depending on amount of decks.
        /// </summary>
        private void CreateDeck()
        {
            for (int x = 0; x < AmountOfDecks; x++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 14; j++)
                    {
                        cardDeck.Add(new Card((Suit)i, (Value)j));
                    }
                }
            }
        }
        /// <summary>
        /// Give cards to all players hands
        /// </summary>
        private void GiveCards()
        {
            IsDone = false;
            for (int i = 0; i < playerManager.Count; i++)
            {
                CheckDeck();
                playerManager.GetAt(i).AddCard(cardDeck[0]);
                cardDeck.RemoveAt(0);
                CheckDeck();
                playerManager.GetAt(i).AddCard(cardDeck[0]);
                cardDeck.RemoveAt(0);
            }
        }
        /// <summary>
        /// Reshuffles the deck with the discarded deck.
        /// </summary>
        public void Reshuffle()
        {
            cardDeck.AddRange(discardCardDeck);
            discardCardDeck.Clear();
            //Shuffle deck
            int lastIndex = cardDeck.Count - 1;
            while (lastIndex > 0)
            {
                Card tempCard = cardDeck[lastIndex];
                int randomIndex = new Random().Next(0, lastIndex);
                cardDeck[lastIndex] = cardDeck[randomIndex];
                cardDeck[randomIndex] = tempCard;
                lastIndex--;
            }
        }
        /// <summary>
        /// Give card to a player and check if the hand is larger than 21.
        /// </summary>
        public bool Hit()
        {
            Player player = playerManager.GetAt(activePlayerIndex);
            CheckDeck();
            player.Hand.AddCard(cardDeck[0]);
            Logger.LogMessage(GetPlayer()?.ToString() + " did hit a " + cardDeck[0].ToString());
            cardDeck.RemoveAt(0);
            if(player.Score > 21)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the deck needs to be reshuffled to continue playing.
        /// </summary>
        private void CheckDeck()
        {
            if (cardDeck.Count == 0)
            {
                Reshuffle();
            }
        }
        /// <summary>
        /// Updates player until player is not equal to amount of players. Returns true or false.
        /// </summary>
        /// <returns></returns>
        public bool UpdatePlayer()
        {
            if (activePlayerIndex < playerManager.Count - 1)
            {
                activePlayerIndex++;

                return false;
            }

            return true;
        }

        public Player? GetPlayer()
        {
            return playerManager.GetAt(activePlayerIndex);
        }

        public Player? GetDealer()
        {
            return playerManager.List.Find(p => p.Name.Contains("Dealer"));
        }

        public bool Stand()
        {
            Logger.LogMessage(GetPlayer()?.ToString() + " did stand!");
            bool isEnding = UpdatePlayer();
            if (!isEnding)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the score after the game is finished. Counting against the dealer and see who won.
        /// </summary>
        public void CheckScore()
        {
            IsDone = true;
            Player? dealer = playerManager.List.Find((x) => x.Name.Contains("Dealer"));

            while (dealer?.Hand.Score < 17)
            {
                CheckDeck();
                dealer.Hand.AddCard(cardDeck[0]);
                cardDeck.RemoveAt(0);
            }

            foreach (Player player in playerManager.List.FindAll((x) => x.Name.Contains("Player")))
            {
                int score = player.Hand.Score;
                if (score < 21 && dealer?.Score > 21)
                {
                    player.Winner = true;
                }
                else if (score > 21 || dealer?.Score == 21 || score == dealer?.Hand.Score)
                {
                    player.Winner = false;
                }
                else if (score > dealer?.Score && score < 22)
                {
                    player.Winner = true;
                }
                else if (score < dealer?.Hand.Score && dealer?.Hand.Score < 22)
                {
                    player.Winner = false;
                }
            }
        }
        /// <summary>
        /// Discard all cards from every hand. And add it to the discardCardDeck.
        /// </summary>
        private void DiscardAllCards()
        {
            foreach (Player player in playerManager.List)
            {
                discardCardDeck.AddRange(player.Hand.Cards);
                player.Hand.Clear();
            }
        }

        public void RestartGame()
        {
            DiscardAllCards();
            activePlayerIndex = playerManager.List.FindIndex((x) => x.Name.Contains("Player"));
            GiveCards();
        }

        public List<Player> GetWinners()
        {
            CheckScore();
            return playerManager.List.FindAll(x => x.Winner == true);
        }
    }
}