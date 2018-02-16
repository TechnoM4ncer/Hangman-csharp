using System;
using System.Linq;

namespace Hangman
{
    class Game
    {
        //Variables
        static Answers a = new Answers();
        static string answer = a.Answer.ToLower();
        string guess;
        string[] correctGuesses = new string[answer.Length];
        int chances = 6;
        int correctCount = 0;

        public Game() {

            //Introduction
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine();
            Console.WriteLine("The word you are guessing has " + answer.Length + " letters!");

            while (correctCount < answer.Length && chances > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Guess a letter!");

                guess = Console.ReadLine();

                //Checks to see if guess is part of the answer, otherwise takes a life
                if (answer.Contains(guess) && !correctGuesses.Contains(guess))
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
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You have already guessed this letter! Try again.");
                    continue;
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
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        //Informs player of correct guess and adds to correctGuesses
        public static void Correct(string[] _correctGuesses, int _chances)
        {
            Console.WriteLine();
            Console.WriteLine("Correct!");
            Console.WriteLine("So far you have: " + "[{0}]", string.Join(", ", _correctGuesses));
            Console.WriteLine("And " + _chances + " more chances!");
            Console.WriteLine();
        }

        //Ends game when player guesses all correct letters
        public static void Wingame()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You win!");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        //Ends game when chances reach 0
        public static void Endgame(string _answer)
        {
            Console.WriteLine("You have run out of guesses! The word was '" + _answer + "'");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
