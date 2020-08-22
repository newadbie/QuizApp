using System;
using QuizApp.Views;

namespace QuizApp
{
    public class Program
    {
        private static void Main()
        {
            QuizView quizView = new QuizView();
            quizView.Greetings();
            quizView.Menu();
        }
    }
}
