using System;
using QuizApp.Controllers;

namespace QuizApp.Views
{
    public class QuizView
    {
        private readonly QuizController _quizController = new QuizController();
        public void Greetings()
        {
            Console.WriteLine("Hello in my quiz application!");
        }

        public void Menu()
        {
            Console.WriteLine("1. Create new quiz!");
            Console.WriteLine("2. Exit game!");
            _quizController.Menu();
        }
    }
}
