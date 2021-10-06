using System;
using System.Collections.Generic;

namespace cse210_tc04
{
    /// <summary>
    /// Represents the thrower in the game. Tracks the dice, the points,
    /// and the decisions around throwing again.
    /// </summary>
    class Chooser
    {

        // TODO: Declare your member variables here
                const int numOfDice = 5;
        List<int> _dice = new List<int>();
        int _numOfThrows = 0;

        /// <summary>
        /// Determines if this is the first roll.
        /// 
        /// The condition is: if the number of throws is 0.
        /// </summary>
        public bool IsFirstGuess()
        {
            return _numOfThrows == 0;
        }

        /// <summary>
        /// Determines if the set of dice contains any that are scoring.
        /// 
        /// The condition is: if there is a 1 or a 5 in the list.
        /// </summary>
        public bool ContainsScoringDie()
        {
            return _dice.Contains(1) || _dice.Contains(5);
        }
        
        /// <summary>
        /// Determines if the player can throw again.
        /// 
        /// The condition is: if it is the first throw or if the current roll
        /// contains a scoring die. (Hint, there are methods for those...)
        /// </summary>
        public bool CanThrow()
        {
            return IsFirstGuess() || ContainsScoringDie();
        }

        /// <summary>
        /// Clears the previous roll and throws a new set of dice.
        /// This also increments the number of throws counter.
        /// 
        /// The new roll will contain NUM_DICE random numbers from 1-6.
        /// </summary>
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

        /// <summary>
        /// Gets the number of points associated with a single die.
        /// 
        /// The rules are:
        ///     Die value 1: 100 Points
        ///     Die value 5: 50 Points
        ///     Other values: 0 Points
        /// </summary>
        /// <param name="die">The provided die value.</param>
        /// <returns>The points associated with the provided die value.</returns>
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

        /// <summary>
        /// Gets the number of points associated with the current roll.
        /// 
        /// (Hint: There is a method to determine the points for a single die
        /// that can be called once for each die value in the current list.)
        /// </summary>
        /// <returns>The number of points.</returns>
        public int GetPoints()
        {
            int points = 0;

            foreach (int die in _dice)
            {
                points += GetPointsForDie(die);
            }

            return points;
        }

        /// <summary>
        /// Gets a list of the current dice in the format:
        ///     [3, 2, 6, 3, 1]
        /// </summary>
        /// <returns></returns>
        public string GetDiceString()
        {
            string commaList = string.Join(", ", _dice);
            string result = "[" + commaList + "]";

            return result;
        }
    }
}
