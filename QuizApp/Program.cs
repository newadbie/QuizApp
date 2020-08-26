using System;
using QuizApp.Views;

namespace QuizApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            QuizView quizView = new QuizView();

            for (;;)
            {
                quizView.Greetings();
                quizView.Menu();
            }
        }
    }
}
