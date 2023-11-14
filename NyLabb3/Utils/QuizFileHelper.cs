using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using NyLabb3.Models;

namespace NyLabb3
{


    namespace Labb3_NET22.Helpers
    {
        public static class QuizFileHelper
        {
            private static string quizFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lab3quiz");

            public static void SaveQuiz(Quiz quiz)
            {
                Directory.CreateDirectory(quizFolderPath);

                string json = JsonConvert.SerializeObject(quiz);
                File.WriteAllText(Path.Combine(quizFolderPath, $"{quiz.Title}.json"), json);
            }

            public static List<Quiz> LoadQuizzes()
            {
                List<Quiz> quizzes = new List<Quiz>();

                if (Directory.Exists(quizFolderPath))
                {
                    foreach (string file in Directory.GetFiles(quizFolderPath, "*.json"))
                    {
                        string json = File.ReadAllText(file);
                        quizzes.Add(JsonConvert.DeserializeObject<Quiz>(json));
                    }
                }

                return quizzes;
            }
        }
    }


}
