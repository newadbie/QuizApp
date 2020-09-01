using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp
{
    public class Application : IApplication
    {
        private readonly List<Quiz> _quizzes = new List<Quiz>();
        private readonly GameConfiguration _gameConfiguration;

        public Application(GameConfiguration gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        public List<Quiz> GetQuizzes() => _quizzes;

        public int GetMaxNumberOfQuestions() => _gameConfiguration.MaxQuestions;

        public int GetNumberOfAnswers() => _gameConfiguration.NumberOfAnswers;

        public void AddQuiz(Quiz quizToAdd)
        {
            _quizzes.Add(quizToAdd);
        }

        public int GetNumberOfQuizzes() => _quizzes.Count;
    }
}
