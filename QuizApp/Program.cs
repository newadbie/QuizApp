using System;
using QuizApp.Views;

namespace QuizApp
{
    public class Program
    {
        private static void Main()
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
