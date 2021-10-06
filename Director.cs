using System;

namespace cse210_tc04
{
    /// <summary>
    /// Like a director in a play, this class is responsible for the game, the script,
    /// the actors, and all of their interactions.
    /// 
    /// For this program, it has responsibility for the score, coordinating with the
    /// player to roll, and the sequence of play.
    /// </summary>
    class Director
    {
        bool _keepPlaying = true;
        int _score = 0;
        Chooser _chooser = new Chooser();

        public void StartGame()
        {
            while (_keepPlaying)
            {
                GetInputs();

                if (_keepPlaying)
                {
                    DoUpdates();
                    DoOutputs();
                }
            }
        }

        void GetInputs()
        {
            if (!_chooser.IsFirstGuess())
            {
                Console.WriteLine("Keep playing? [y/n] ");
                string choice = Console.ReadLine();
                _keepPlaying = (choice == "y");
            }
        }

        void DoUpdates()
        {
            _chooser.MakeChoice();

            if (_chooser.ContainsScoringDie())
            {
                _score += _chooser.GetPoints();
            }
            else
            {
                _score = 0;
            }
        }

        void DoOutputs()
        {
            string diceString = _chooser.GetDiceString();

            Console.WriteLine();
            Console.WriteLine($"The card is: {diceString}");
            Console.WriteLine($"Your score is: {_score}");

            if (!_chooser.CanThrow())
            {
                Console.WriteLine("Game Over.");
                _keepPlaying = false;
            }
        }

    } // end of class: Director
}
