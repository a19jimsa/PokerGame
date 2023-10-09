using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameCardLib
{
    public class Hand
    {
        private Deck deck;
        public Card LastCard { get { return deck.GetAt(deck.NumberOfCards() - 1); } }
        public int NumberOfCards { get { return deck.NumberOfCards(); } }
        public int Score { get { return deck.SumOfCards(); } }

        public List<Card> Cards {  get { return deck.Cards; } }

        public Hand(Deck deck)
        {
            this.deck = deck;
        }

        public void AddCard(Card card)
        {
            deck.AddCard(card);
        }
        public void Clear()
        {
            deck.DiscardCards();
        }
        public override string ToString()
        {
            return $"Score: {this.deck.SumOfCards()}";
        }

    }
}
