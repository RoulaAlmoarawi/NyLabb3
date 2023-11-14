using Newtonsoft.Json;
using NyLabb3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace NyLabb3
{
    public partial class CreateNewQuizWindow : Window
    {
        private List<Question> questions = new List<Question>();
        private string quizFolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lab3quiz");

        public CreateNewQuizWindow()
        {
            InitializeComponent();
            Directory.CreateDirectory(quizFolderPath); 
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
           
            questions.Add(new Question(
                QuestionTextBox.Text,
                CorrectAnswerComboBox.SelectedIndex,
                new string[] { Answer1TextBox.Text, Answer2TextBox.Text, Answer3TextBox.Text }));

            
            QuestionTextBox.Clear();
            Answer1TextBox.Clear();
            Answer2TextBox.Clear();
            Answer3TextBox.Clear();
            CorrectAnswerComboBox.SelectedIndex = -1;
        }

        private void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
           
            Quiz newQuiz = new Quiz(QuizTitleTextBox.Text) { Questions = questions };

           
            string json = JsonConvert.SerializeObject(newQuiz, Formatting.Indented);

          
            string filePath = Path.Combine(quizFolderPath, $"{newQuiz.Title}.json");
            File.WriteAllText(filePath, json);

            MessageBox.Show("Quiz saved successfully!");
        }
    }
}
