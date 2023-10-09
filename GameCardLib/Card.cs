using System;

namespace GameCardLib
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Value Value { get; set; }

        public Card(Suit suit, Value value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public Uri FilePath
        {
            get{
                string location = System.Reflection.Assembly.GetEntryAssembly().Location;
                string path = location;
                Uri baseUri = new Uri(path);
                Uri myUri = new Uri(baseUri, "../../../Assets/BACK.png");

                if (this.Suit == Suit.clubs && this.Value == Value.Ace)
                {
                    myUri = new Uri(baseUri, "../../../Assets/A-C.png");
                    return myUri;
                }
                else if(this.Suit == Suit.clubs && this.Value == Value.King)
                {
                    myUri = new Uri(baseUri, "../../../Assets/K-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Queen)
                {
                    myUri = new Uri(baseUri, "../../../Assets/Q-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Jack)
                {
                    myUri = new Uri(baseUri, "../../../Assets/J-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Ten)
                {
                    myUri = new Uri(baseUri, "../../../Assets/10-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Nine)
                {
                    myUri = new Uri(baseUri, "../../../Assets/9-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Eight)
                {
                    myUri = new Uri(baseUri, "../../../Assets/8-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Seven)
                {
                    myUri = new Uri(baseUri, "../../../Assets/7-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Six)
                {
                    myUri = new Uri(baseUri, "../../../Assets/6-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Five)
                {
                    myUri = new Uri(baseUri, "../../../Assets/5-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Four)
                {
                    myUri = new Uri(baseUri, "../../../Assets/4-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Three)
                {
                    myUri = new Uri(baseUri, "../../../Assets/3-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.clubs && this.Value == Value.Two)
                {
                    myUri = new Uri(baseUri, "../../../Assets/2-C.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Ace)
                {
                    myUri = new Uri(baseUri, "../../../Assets/A-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.King)
                {
                    myUri = new Uri(baseUri, "../../../Assets/K-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Queen)
                {
                    myUri = new Uri(baseUri, "../../../Assets/Q-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Jack)
                {
                    myUri = new Uri(baseUri, "../../../Assets/J-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Ten)
                {
                    myUri = new Uri(baseUri, "../../../Assets/10-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Nine)
                {
                    myUri = new Uri(baseUri, "../../../Assets/9-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Eight)
                {
                    myUri = new Uri(baseUri, "../../../Assets/8-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Seven)
                {
                    myUri = new Uri(baseUri, "../../../Assets/7-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Six)
                {
                    myUri = new Uri(baseUri, "../../../Assets/6-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Five)
                {
                    myUri = new Uri(baseUri, "../../../Assets/5-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Four)
                {
                    myUri = new Uri(baseUri, "../../../Assets/4-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Three)
                {
                    myUri = new Uri(baseUri, "../../../Assets/3-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.diamonds && this.Value == Value.Two)
                {
                    myUri = new Uri(baseUri, "../../../Assets/2-D.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Ace)
                {
                    myUri = new Uri(baseUri, "../../../Assets/A-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.King)
                {
                    myUri = new Uri(baseUri, "../../../Assets/K-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Queen)
                {
                    myUri = new Uri(baseUri, "../../../Assets/Q-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Jack)
                {
                    myUri = new Uri(baseUri, "../../../Assets/J-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Ten)
                {
                    myUri = new Uri(baseUri, "../../../Assets/10-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Nine)
                {
                    myUri = new Uri(baseUri, "../../../Assets/9-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Eight)
                {
                    myUri = new Uri(baseUri, "../../../Assets/8-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Seven)
                {
                    myUri = new Uri(baseUri, "../../../Assets/7-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Six)
                {
                    myUri = new Uri(baseUri, "../../../Assets/6-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Five)
                {
                    myUri = new Uri(baseUri, "../../../Assets/5-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Four)
                {
                    myUri = new Uri(baseUri, "../../../Assets/4-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Three)
                {
                    myUri = new Uri(baseUri, "../../../Assets/3-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.hearts && this.Value == Value.Two)
                {
                    myUri = new Uri(baseUri, "../../../Assets/2-H.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Ace)
                {
                    myUri = new Uri(baseUri, "../../../Assets/A-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.King)
                {
                    myUri = new Uri(baseUri, "../../../Assets/K-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Queen)
                {
                    myUri = new Uri(baseUri, "../../../Assets/Q-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Jack)
                {
                    myUri = new Uri(baseUri, "../../../Assets/J-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Ten)
                {
                    myUri = new Uri(baseUri, "../../../Assets/10-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Nine)
                {
                    myUri = new Uri(baseUri, "../../../Assets/9-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Eight)
                {
                    myUri = new Uri(baseUri, "../../../Assets/8-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Seven)
                {
                    myUri = new Uri(baseUri, "../../../Assets/7-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Six)
                {
                    myUri = new Uri(baseUri, "../../../Assets/6-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Five)
                {
                    myUri = new Uri(baseUri, "../../../Assets/5-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Four)
                {
                    myUri = new Uri(baseUri, "../../../Assets/4-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Three)
                {
                    myUri = new Uri(baseUri, "../../../Assets/3-S.png");
                    return myUri;
                }
                else if (this.Suit == Suit.spades && this.Value == Value.Two)
                {
                myUri = new Uri(baseUri, "../../../Assets/2-S.png");
                return myUri;
            }
                return myUri;
            }
            set
            {

            }
        }

        public override string ToString()
        {
            return $"{Suit} {Value}";
        }
    }
}