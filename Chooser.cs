using System;
using System.Collections.Generic;

namespace cse210_tc04
{
    
    class Chooser
    {
        const int NUM_DICE = 5;
        const int numOfDice = 5;
        List<int> _dice = new List<int>();
        int _numOfThrows = 0;


        public bool IsFirstGuess()
        {
            return _numOfThrows == 0;
        }

      
        public bool ContainsScoringDie()
        {
            return _dice.Contains(1) || _dice.Contains(5);
        }
     
        public bool CanThrow()
        {
            return IsFirstGuess() || ContainsScoringDie();
        }

       
        public void MakeChoice()
        {
            _numOfThrows++;
            _dice.Clear();

            Random randomGenerator = new Random();

            for(int i = 0; i < numOfDice; i++)
            {
                int die = randomGenerator.Next(1,7);
                _dice.Add(die);
            }
        }

     
        public int GetPointsForDie(int die)
        {
            int points = 0;

            if (die == 1)
            {
                points = 100;
            }
            else if (die == 5)
            {
                points = 50;
            }

            return points;
        }

       
        public int GetPoints()
        {
            int points = 0;

            foreach (int die in _dice)
            {
                points += GetPointsForDie(die);
            }

            return points;
        }

   
        public string GetDiceString()
        {
            string commaList = string.Join(", ", _dice);
            string result = "[" + commaList + "]";

            return result;
        }
    }
}
