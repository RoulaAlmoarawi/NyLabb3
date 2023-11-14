using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using NyLabb3.Labb3_NET22.Helpers;
using NyLabb3.Models;
using System.Windows;

namespace NyLabb3.ViewModel
{

    public class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Quiz _currentQuiz;
        private Question _currentQuestion;
        private int _currentAnswer;
        private int _score;
        private ICommand _submitAnswerCommand;
        private bool currentAnswerCorrect = false;

        public Quiz CurrentQuiz
        {
            get => _currentQuiz;
            set { _currentQuiz = value; OnPropertyChanged(nameof(CurrentQuiz)); }
        }

        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set { _currentQuestion = value; OnPropertyChanged(nameof(CurrentQuestion)); }
        }

        public int CurrentAnswer
        {
            get => _currentAnswer;
            set { _currentAnswer = value; OnPropertyChanged(nameof(CurrentAnswer)); }
        }

       
        public string ScoreText => $"Score: {_score}";

        public ICommand SubmitAnswerCommand
        {
            get
            {
                if (_submitAnswerCommand == null)
                {
                    _submitAnswerCommand = new RelayCommand(param => AnswerQuestion(), param => CanAnswerQuestion());
                }
                return _submitAnswerCommand;
            }
        }

        public void LoadQuiz(string quizTitle)
        {
            List<Quiz> quizzes = QuizFileHelper.LoadQuizzes();
            CurrentQuiz = quizzes[0];
            CurrentQuestion = quizzes[0].GetRandomQuestion();
        }

        public bool isAnswerCorrect()
        {
            return currentAnswerCorrect;
        }

        private void AnswerQuestion()
        {
            if (CurrentQuestion.CorrectAnswer == CurrentAnswer)
            {
                _score++;
                MessageBox.Show("Great Job!", "Quiz App", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Hard Luck!", "Quiz App", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            CurrentQuestion = _currentQuiz.GetRandomQuestion();
           // currentAnswerCorrect = false;
            OnPropertyChanged(nameof(ScoreText));
            CurrentAnswer = -1;
        }

        private bool CanAnswerQuestion()
        {
            return CurrentAnswer != -1;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
    }

    
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }



}
