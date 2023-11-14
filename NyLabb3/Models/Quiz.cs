using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyLabb3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class Quiz
    {
        private List<Question> _questions;
        private string _title = string.Empty;
        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        public string Title => _title;

        [JsonConstructor]
        public Quiz(string title)
        {
            _title = title;
            _questions = new List<Question>();
        }

        public Question GetRandomQuestion()
        {
            Random rand = new Random();
            return _questions[rand.Next(_questions.Count)];
        }

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {
            _questions.Add(new Question(statement, correctAnswer, answers));
        }

        public void RemoveQuestion(int index)
        {
            if (index >= 0 && index < _questions.Count)
            {
                _questions.RemoveAt(index);
            }
        }
    }

}
