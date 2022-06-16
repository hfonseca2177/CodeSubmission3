using System;


namespace CodeSubmission3
{
    //Card with number and suit
    internal class Card
    {
        private int number;
        private Suit suit;

        public Card(int number, Suit suit)
        {
            this.number = number;
            this.suit = suit;
        }

        //Prints which card it is
        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.White;
            if (Suit.HEARTS.Equals(suit) || Suit.DIAMONDS.Equals(suit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(PrintableCardNumber(this.number) + " " + GetSuitUCode());
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        //Parse the card number to Rank
        private string PrintableCardNumber(int number)
        {
            string cardNumber;
            switch (number) {
                case 13: cardNumber = "K"; break;
                case 12: cardNumber = "Q"; break;
                case 11: cardNumber = "J"; break;
                case 1: cardNumber = "A"; break;
                default: cardNumber = number.ToString(); break;
            }
            return cardNumber;
        }

        private string GetSuitUCode()
        {
            string suitUCode;
            switch (suit) 
            { 
                case Suit.SPADES:
                    {
                        suitUCode = "\u2660";
                        break;
                    }
                case Suit.HEARTS:
                    {
                        suitUCode = "\u2665";
                        break;
                    }
                case Suit.CLUBS:
                    {
                        suitUCode = "\u2663";
                        break;
                    }
                default:
                    {
                        //DIAMONDS
                        suitUCode = "\u2666";
                        break;
                    }
            }
            return suitUCode;
        }

        //Returns the card number weight
        public int Number()
        {
            return number;
        }
    }
}
