using System;

namespace cse210_tc04
{
   
    class Director
    {
        bool _keepPlaying = true;
        int _score = 300;
        Chooser _chooser = new Chooser();
        int _card1 = 0;
        int _card2 = 0;

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
                Console.WriteLine("Roll again? [y/n] ");
                string choice = Console.ReadLine();
                _keepPlaying = (choice == "y");
            }
        }

        void DoUpdates()
        {
            _card1 = _chooser.GetNewCard();
            _card2 = _chooser.GetNewCard();
            
        }

        void DoOutputs()
        {

            Console.WriteLine();
            Console.WriteLine($"The card is: {_card1}");
            Console.WriteLine("Is next card Higher or Lower [h/]l]? ");
            string choice = Console.ReadLine();
            
            string verdict = _chooser.CompareCards(_card1, _card2);

            bool x = _chooser.ChoiceVerdict(choice, verdict);

            
            Console.WriteLine($"Your score is: {_score}");

            if (!_chooser.CanThrow())
            {
                Console.WriteLine("Game Over");
                _keepPlaying = false;
            }
        }
    } // end of class: Director
}
