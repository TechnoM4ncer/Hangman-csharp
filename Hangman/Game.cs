using System;
using System.Linq;

namespace Hangman
{
    class Game
    {
        //Variables
        private Answers a;
        private string answer;
        private string[] correctGuesses;
        private string guess;
        private int chances;
        private int correctCount;

        //Constructor
        public Game() {
            Start();
        }

        //Starts game
        private void Start()
        {
            a = new Answers();
            answer = a.Answer;
            chances = 6;
            correctCount = 0;
            correctGuesses = new string[answer.Length];

            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine();
            Console.WriteLine("The word you are guessing has " + answer.Length + " letters!");

            Guess();
        }

        private void Guess()
        {
            while (correctCount < answer.Length && chances > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Guess a letter!");

                guess = Console.ReadLine();

                Check();
            }
        }

        private void Check()
        {
            //Checks to see if guess is part of the answer, otherwise takes a life
            if (answer.IndexOf(guess, StringComparison.InvariantCultureIgnoreCase) >= 0 && !correctGuesses.Contains(guess))
            {

                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == guess[0])
                    {
                        correctGuesses[i] = answer[i].ToString();
                        correctCount++;
                    }

                }

                Correct(correctGuesses, chances);

                if (correctCount >= answer.Length)
                {
                    Wingame();
                }
            }
            else if (correctGuesses.Contains(guess))
            {
                Console.WriteLine("You have already guessed this letter! Try again.");
            }
            else
            {
                chances--;
                Console.WriteLine();
                Console.WriteLine("Sorry that is incorrect! You have " + chances + " chances left");

                //Ends game when lives reach 0
                if (chances == 0)
                {
                    Endgame(answer);
                }
            }
        }

        //Informs player of correct guess and adds to correctGuesses
        private void Correct(string[] _correctGuesses, int _chances)
        {
            Console.WriteLine();
            Console.WriteLine("Correct!");
            Console.WriteLine("So far you have: " + "[{0}]", string.Join(", ", _correctGuesses));
            Console.WriteLine("And " + _chances + " more chances!");
            Console.WriteLine();
        }

        //Ends game when player guesses all correct letters
        private void Wingame()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You win!");
            Console.WriteLine("\n Press y to play again, or any other key to close");
            if (Console.ReadKey().Key.ToString() == "Y")
            {
                Start();
            }
            else
            {
                Close();
            }
        }

        //Ends game when chances reach 0
        private void Endgame(string _answer)
        {
            Console.Clear();
            Console.WriteLine("You have run out of guesses! The word was '" + _answer + "'");
            Console.WriteLine("Press y to play again, or any other key to close");
            if (Console.ReadKey().Key.ToString() == "Y")
            {
                Start();
            }
            else
            {
                Close();
            }
        }

        private void Close()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Thanks for playing! Press any key to close.");
            Console.ReadKey();
        }
    }
}