using System;
using System.Collections.Generic;

namespace cse210_tc04
{
    
    class Chooser
    {
        int _card1 = 0;
        int _card2 = 0;
        int _numOfTurns = 0;

        // 
        public bool IsFirstGuess()
        {
            return _numOfTurns == 0;
        }

        // generates random card
        public int GetNewCard() 
        {
            Random randomGenerator = new Random();
            int card = randomGenerator.Next(1,14);

            return card;

        }

        // determines if the 2nd card is higher or lower than the first
        public string CompareCards(int card1, int card2)
        {
            if (card2 >= card1)
            {
                return "h";
            }
            else 
            {
                return "l";
            }
        }
        // compares the user's choice to the actual result and returns whether 
        // the user was right or wrong
        public bool ChoiceVerdict(string choice, string verdict)
        {
            return false;
        }

        // determines the point total
        public int GetPoints(bool result, int _score)
        {
            return _score;
        }
    }
}
