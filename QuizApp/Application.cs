using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp
{
    public class Application : IApplication
    {
        private readonly List<Quiz> _quizzes = new List<Quiz>();
        private readonly GameConfiguration _gameConfiguration;
        private readonly ApplicationContext _applicationContext;

        public Application(GameConfiguration gameConfiguration, ApplicationContext applicationContext)
        {
            _gameConfiguration = gameConfiguration;
            _applicationContext = applicationContext;
        }

        public ApplicationContext GetContext() => _applicationContext;

        public List<Quiz> GetQuizzes() => _quizzes;

        public int GetMaxNumberOfQuestions() => _gameConfiguration.MaxQuestions;

        public int GetNumberOfAnswers() => _gameConfiguration.NumberOfAnswers;

        public void AddQuiz(Quiz quizToAdd)
        {
            _applicationContext.Add(quizToAdd);
            _applicationContext.SaveChanges();
            _quizzes.Add(quizToAdd);
        }

        public int GetNumberOfQuizzes() => _quizzes.Count;
    }
}
