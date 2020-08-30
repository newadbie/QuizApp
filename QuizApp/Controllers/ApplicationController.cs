using System;
using System.Collections.Generic;
using QuizApp.Exceptions;
using QuizApp.Models;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Controllers
{
    public class ApplicationController
    {
        private readonly List<Quiz> _quizzes = new List<Quiz>();
        private readonly QuizView _quizView;

        public ApplicationController(QuizView quizView)
        {
            _quizView = quizView;
        }

        public void Elo()
        {
            Console.WriteLine("ELO1");
            _quizView.Elo();
        }

        public List<Quiz> GetQuizzes()
        {
            if (_quizzes.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _quizzes;
        }

        public void ExitApplication()
        {
            Environment.Exit(1);
        }
    }
}
