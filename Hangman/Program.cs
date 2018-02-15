using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Variables
            Answers a = new Answers();
            string answer = a.Answer.ToLower();
            string guess;
            string[] correctGuesses = new string[answer.Length];
            int chances = 6;
            int correctCount = 0;

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

                    Console.WriteLine();
                    Console.WriteLine("Correct!");
                    Console.WriteLine("So far you have: " + "[{0}]", string.Join(", ", correctGuesses));
                    Console.WriteLine("And " + chances + " more chances!");
                    Console.WriteLine();
                    continue;

                    if (correctCount >= answer.Length)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations! You win!");
                        Console.WriteLine("Press any key to play again");
                        Console.ReadKey();
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
                        Console.WriteLine("You have run out of guesses! The word was '" + answer + "'");
                        Console.WriteLine("Press any key to play again");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}