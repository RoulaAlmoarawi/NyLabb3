using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NyLabb3.ViewModel;

namespace NyLabb3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private QuizViewModel _quizViewModel;

        public QuizWindow()
        {
            InitializeComponent();
            _quizViewModel = new QuizViewModel();
            DataContext = _quizViewModel;
            _quizViewModel.LoadQuiz("SampleQuiz");
        }

        private bool CheckAnswer()
        {
            return _quizViewModel.isAnswerCorrect();
        }

    }


}
