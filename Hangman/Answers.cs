using System;
using System.IO;

namespace Hangman
{
    class Answers
    {
        //Variables
        private static string[] answersList;
        static Random r;
        private int randomLineNumber;
        private string answer;

        //Getter
        public string Answer
        {
            get
            {
                answersList = File.ReadAllLines(@"answers.txt");
                r = new Random();
                randomLineNumber = r.Next(0, answersList.Length - 1);
                answer = answersList[r.Next(answersList.Length)];
                return answer;
            }
        }
    }
}
