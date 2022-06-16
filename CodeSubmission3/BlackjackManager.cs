using System;
using System.Collections.Generic;
using Util;

namespace CodeSubmission3
{
    //Game manager
    internal class BlackjackManager
    {
        List<Card> playerHand;
        List<Card> dealerHand;
        CardDeck deck;
        bool gameOver = false;
        bool gameOn = false;

        //Creates deck and 
        public void Init()
        {
            PrintRules();
            this.deck = new CardDeck();
            this.deck.InitDeck();
        }

        private void ResetHands()
        {
            this.playerHand = new List<Card>();
            this.dealerHand = new List<Card>();
        }

        public void Play()
        {
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

        public void StandChoice()
        {   
            Print("==================== Final Result ===================", ConsoleColor.Yellow);
            Print("");
            PrintHand(ref playerHand);
            Print("");
            PrintHand(ref dealerHand);
            Print("");
            gameOn = false;
            //TODO process result
            //Console.ReadKey();
            Print("=====================================================", ConsoleColor.Yellow);
        }

        public void HitChoice()
        {
            playerHand.Add(this.deck.Draw());
            Print("Your hand :");
            PrintHand(ref playerHand);
            //TODO evaluate total in hand
        }

        public void ExitGame()
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

        public void PrintRules()
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

        protected void Print(string message)
        {
            Console.WriteLine(message);
        }

        protected void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Print(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
