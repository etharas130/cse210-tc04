using System;

namespace cse210_tc04
{
   /// <summary>
   /// Represents the director of the game. Tracks the start of the game, whether the chooser is still playing,
   /// and plays the game.
   /// <summary>
    class Director
    {
        bool _keepPlaying = true;
        int _score = 300;
        Chooser _chooser = new Chooser();
        int _card1 = 0;
        int _card2 = 0;

        public void DoIntro()
        {
            Console.WriteLine("Welcome to HiLo! You start with 300 points!");
        }

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

        // asks the chooser whether they want to keep playing after the score is counted
        void GetInputs()
        {
            if (_chooser.IsFirstGuess())
            {
                Console.Write("Keep Playing? [y/n] ");
                string choice = Console.ReadLine();
                //_keepPlaying = (choice == "y");
                if (choice == "y")
                {
                    _keepPlaying = true;
                }
                else
                {
                    _keepPlaying = false;
                    Console.WriteLine("Goodbye!");
                }
            }
        }

        // chooses the next cards for comparing
        void DoUpdates()
        {
            _card1 = _chooser.GetNewCard();
            _card2 = _chooser.GetNewCard();
            
        }

        // plays the game
        void DoOutputs()
        {

            Console.WriteLine();
            Console.WriteLine($"The first card is: {_card1}");
            //Console.WriteLine($"TESTING_CHEAT_SECOND_CARD: {_card2}");

            Console.Write("Is the next card Higher or Lower [h/l]? ");
            string choice = Console.ReadLine();

            //Console.WriteLine($"Your choice: {choice}");
            Console.WriteLine($"The second card was: {_card2}");
            
            string verdict = _chooser.CompareCards(_card1, _card2);
            bool result = _chooser.ChoiceVerdict(choice, verdict);
            _score = _chooser.GetPoints(result, _score); 
            
            Console.WriteLine($"Your score is: {_score}");

            if (_score <= 0)
            {
                Console.WriteLine("Game Over");
                _keepPlaying = false;
            }
        }
    } // end of class: Director
}
