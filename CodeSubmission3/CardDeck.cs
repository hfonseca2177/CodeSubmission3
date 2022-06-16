using System;

namespace CodeSubmission3
{
    //Full Card Deck
    //Holds an instance card for each rank and suit
    internal class CardDeck
    {
        private Card[] cards;
        private const int MAX_CARDS_SUIT = 13;
        private const int MAX_CARDS = 52;
        private int lastCardDrawn = 0;

        //Instantiate full deck
        public void InitDeck()
        {
            cards = new Card[MAX_CARDS];
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
            if(DeckIsOver())
            {
                throw new Exception("Deck is Over");
            }
            Card cardDrawn = cards[lastCardDrawn];
            lastCardDrawn++;
            return cardDrawn;
        }
        //Return if there is no more cards to draw
        public bool DeckIsOver()
        {
            return lastCardDrawn == (MAX_CARDS-1);
        }
    }


}
