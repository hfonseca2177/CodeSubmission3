using System;
using System.Collections.Generic;
using Util;

namespace CodeSubmission3
{
    //Blackjack Game manager
    //Execute the gameloop, and evaluates the result hands
    internal class BlackjackManager
    {
        List<Card> playerHand;
        List<Card> dealerHand;
        CardDeck deck;
        bool gameOver = false;
        bool gameOn = false;

        //Creates deck and 
        private void Init()
        {
            PrintRules();
            this.deck = new CardDeck();
            this.deck.InitDeck();
        }
        //Clean hands collections
        private void ResetHands()
        {
            this.playerHand = new List<Card>();
            this.dealerHand = new List<Card>();
        }
        //Execute the game play loop
        public void Play()
        {
            Init();
            SubscribeUserChoices();
            while (true)
            {
                if (gameOver)
                {
                    break;
                }
                if(gameOn)
                {
                    Print("(1) Stand or (2) Hit (Q) quit: ");
                    UserInputHandler.HandleInput();
                }
                else 
                {   
                    deck.ShufflesDeck();
                    ResetHands();
                    StartingHand();
                }
                
            }
            Destroy();
        }
        //Deals initial hand
        private void StartingHand()
        {
            Print("======================================================", ConsoleColor.Green);
            Print("Starting Hands :");
            //Deal cards between player and dealer
            playerHand.Add(this.deck.Draw());
            dealerHand.Add(this.deck.Draw());
            playerHand.Add(this.deck.Draw());
            dealerHand.Add(this.deck.Draw());
            Print("Your hand :");
            PrintHand(ref playerHand);
            gameOn = true;
        }
        //Keeps hand and see results
        private void StandChoice()
        {   
            Print("\n==================== FINAL RESULT ===================\n", ConsoleColor.Magenta);
            Print("Your Hand: ");
            PrintHand(ref playerHand);            
            Print("\nDealer's Hand: ");
            PrintHand(ref dealerHand);
            Print("\n=====================================================\n\n", ConsoleColor.Magenta);
            gameOn = false;
        }
        //Hit - Draws another card
        private void HitChoice()
        {
            playerHand.Add(this.deck.Draw());
            Print("\nYour hand :");
            PrintHand(ref playerHand);
        }

        //Changes flag to exit loop
        private void ExitGame()
        {
            gameOver = true;
        }

        //Assign a callback function for each Key [1-2] and X to exit
        private void SubscribeUserChoices()
        {
            UserInputHandler.KeyOnePressed += StandChoice;
            UserInputHandler.KeyTwoPressed += HitChoice;
            UserInputHandler.KeyQPressed += ExitGame;
        }

        //Remove all subscriptions to actions
        private void Destroy()
        {
            UserInputHandler.KeyOnePressed -= StandChoice;
            UserInputHandler.KeyTwoPressed -= HitChoice;
            UserInputHandler.KeyQPressed -= ExitGame;
            Print("Farewell!!!!", ConsoleColor.Cyan);
        }

        //Interact through all cards in hand and print it
        private void PrintHand(ref List<Card> hand)
        {   
            if(hand.Count > 0)
            {
                foreach (Card card in hand)
                {
                    card.Print();
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        private void PrintRules()
        {
            Print("################ Welcome to Blackjack ################ ", ConsoleColor.Green);
            Print("It is You against the Dealer !!!!");
            Print("======================================================");
            Print("A - worth 1 or 11");
            Print("K, Q, J and 10 - worth 10");
            Print("Other cards worth its own number");            
            Print("Closest to 21 wins");
            Print("You can choose to [Stand] and keep your hand or");
            Print("[Hit] and Draw another card");
            Print("======================================================");
            Print("#######################################################", ConsoleColor.Green);
        }

        private void Print(string message)
        {
            Console.WriteLine(message);
        }

        private void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Print(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
