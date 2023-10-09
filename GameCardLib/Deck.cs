using Accessibility;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace GameCardLib
{
    public class Deck
    {
        private readonly List<Card> cards;

        public bool GameIsDone { get; set; }

        public List<Card> Cards { get { return cards; } set { } }

        public Deck(List<Card> cardList)
        {
            cards = new List<Card>();
            InitializeDeck(cardList);
        }
        /// <summary>
        /// Add card to the deck.
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        /// <summary>
        /// Clears the deck.
        /// </summary>
        public void DiscardCards()
        {
            cards.Clear();
        }

        public Card GetAt(int position)
        {
            return cards[position];
        }
        /// <summary>
        /// Create deck to players/dealers, gives two cards from the param cardList and removes 2 from it.
        /// </summary>
        /// <param name="cardList"></param>
        private void InitializeDeck(List<Card> cardList)
        {
            for(int i = 0; i < 2; i++)
            {
                cards.Add(cardList[0]);
                cardList.RemoveAt(0);
            }
        }
        /// <summary>
        /// Return number of cards in deck
        /// </summary>
        /// <returns></returns>
        public int NumberOfCards()
        {
            return cards.Count;
        }
        /// <summary>
        /// Shuffle the deck. Listens to delegate events.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventArgs"></param>
        public void OnShuffle(object source, EventArgs eventArgs)
        {
            
        }
        /// <summary>
        /// Removes the card at index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveCard(int index)
        {
            cards.RemoveAt(index);
        }
        /// <summary>
        /// Adds the total sum of the cards. Ace can be 1 or 11. It depends on the other cards values. And are evaluated dependings on other cards to get as close to 21 as possible.
        /// </summary>
        /// <returns>Sum</returns>
        public int SumOfCards()
        {
            var sum = 0;
            var aces = 0;
            for(var i = 0; i < cards.Count; i++)
            {
                if ((int)cards[i].Value > 10)
                {
                    sum += 10;
                }
                else if((int)cards[i].Value == 1)
                {
                    aces++;
                    sum += 11;
                }
                else
                {
                    sum += (int)cards[i].Value;
                }

            }
            if(sum > 21)
            {
                while(aces > 0)
                {
                    sum -= 10;
                    aces--;
                    if(sum <= 21)
                    {
                        return sum;
                    }
                }
            }
            return sum;
        }

        public override string ToString()
        {
            var cardNames = "";
            for(var i = 0; i < cards.Count; i++)
            {
                cardNames += cards[i].Suit.ToString() + " " + cards[i].Value.ToString() + "\n";
            }
            return cardNames;
        }
    }
}