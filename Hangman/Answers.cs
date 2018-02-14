using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    class Answers
    {
        //Variables
        private static string[] answersList = File.ReadAllLines(@"answers.txt");
        private static Random r = new Random();
        int randomLineNumber = r.Next(0, answersList.Length - 1);
        public static string answer = answersList[r.Next(answersList.Length)];

        //Getter
        public string Answer {
            get {
                return answer;
            }
        }
            

    }
}
