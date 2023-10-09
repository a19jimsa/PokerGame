using System;

namespace GameCardLib
{
    public class Player
    {
        public string PlayerID { get; set; }
        public string Name { get; set; }
        public Hand Hand { get; set; }
        public bool Winner {get; set; }

        public int NumberOfCards { get { return Hand.NumberOfCards; } }

        public int Score { get { return Hand.Score; } }

        public Player(string id, string name, Hand hand, bool winner)
        {
            PlayerID = id;
            Name = name;
            Hand = hand;
            Winner = winner;
        }

        public void AddCard(Card card)
        {
            Hand.AddCard(card);
        }

        public override string ToString()
        {
            return $"{PlayerID} {Name} {Hand} {Winner}";
        }


    }
}
