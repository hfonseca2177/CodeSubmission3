using System;

namespace CodeSubmission3
{
    /*
     * Intro to Programming in C#
     * Professor: Jarrett McKenna
     * GD67 - Hugo Fonseca
     * 
     * Choosen theme: Card game : Blackjack 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            BlackjackManager blackjackManager = new BlackjackManager();
            blackjackManager.Play();
        }
    }
}
