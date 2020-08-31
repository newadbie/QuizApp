using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp
{
    public class Application : IApplication
    {
        private readonly List<Quiz> _quizzes = new List<Quiz>();

        public List<Quiz> GetQuizzes() => _quizzes;

        public void AddQuiz(Quiz quizToAdd)
        {
            _quizzes.Add(quizToAdd);
        }

        public int GetNumberOfQuizzes() => _quizzes.Count;
    }
}
