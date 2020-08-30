using System;
using System.Collections.Generic;
using System.Text;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class MenuOptionNewQuiz : IMenuOption
    {
        private readonly CreateView _createView;
        private readonly GameConfiguration _gameConfiguration;
        private Quiz newQuiz;

        public MenuOptionNewQuiz(CreateView createView, GameConfiguration gameConfiguration)
        {
            _createView = createView;
            _gameConfiguration = gameConfiguration;
        }

        public void Action()
        {
            _createView.GiveQuizName();
            string quizName = Console.ReadLine();
            newQuiz = Quiz.Create(quizName);
        }

    }
}
