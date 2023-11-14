using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyLabb3.Models
{
    public class Question
    {
        public string Statement { get; }
        public string[] Answers { get; }
        public int CorrectAnswer { get; }

        public Question(string statement, int correctAnswer, params string[] answers)
        {
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }

}
