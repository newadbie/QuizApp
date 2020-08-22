using System;
using System.Collections.Generic;
using QuizApp.Exceptions;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuizController
    {
        private readonly List<Quiz> _quizzes = new List<Quiz>();
        public EMenuOptions SelectOption()
        {
            if (!int.TryParse(Console.ReadLine(), out var opt)
                || Enum.GetName(typeof(EMenuOptions), opt) == null)
            {
                throw new IncorrectInputException();
            }

            EMenuOptions selectedOption = Enum.Parse<EMenuOptions>(Enum.GetName(typeof(EMenuOptions), opt)!);
            return selectedOption;
        }

        public Quiz CreateNewQuiz(string quizTitle)
        {
            var newQuiz = new Quiz(quizTitle);
            _quizzes.Add(newQuiz);
            return newQuiz;
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
