using System;

namespace CodeSubmission3
{
    //Full Card Deck
    //Holds an instance card for each rank and suit
    internal class CardDeck
    {
        private Card[] cards;
        private const int MAX_CARDS_SUIT = 13;
        private int lastCardDrawn = 0;

        //Instantiate full deck
        public void InitDeck()
        {
            cards = new Card[52];
            InstantiateSuit(Suit.DIAMONDS, 0);
            InstantiateSuit(Suit.CLUBS, 13);
            InstantiateSuit(Suit.HEARTS, 26);
            InstantiateSuit(Suit.SPADES, 39);
        }
        //Instantiate a suit
        private void InstantiateSuit(Suit suit, int offset) 
        {
            for (int i = offset; i < MAX_CARDS_SUIT+offset; i++)
            {
                cards[i] = new Card((i+1) - offset, suit);
            }
        }

        //Shuffles Deck
        public void ShufflesDeck()
        {
            this.lastCardDrawn = 0;
            Random randomizer = new Random();
            int deckSize = cards.Length;
            while (deckSize > 1)
            {
                int newShuffledPosition = randomizer.Next(deckSize);
                deckSize--;
                Card temp = cards[deckSize];
                cards[deckSize] = cards[newShuffledPosition];
                cards[newShuffledPosition] = temp;
            }
        }

        //Draws a card from the pile
        public Card Draw()
        {
            Card cardDrawn = cards[lastCardDrawn];
            lastCardDrawn++;
            return cardDrawn;
        }
    }


}
