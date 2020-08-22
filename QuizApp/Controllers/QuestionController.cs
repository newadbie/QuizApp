using System;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuestionController
    {
        private readonly Quiz _quiz;
        private readonly GameConfiguration _gameConfiguration;

        public QuestionController(Quiz currentQuiz, GameConfiguration gameConfiguration)
        {
            _quiz = currentQuiz;
            _gameConfiguration = gameConfiguration;
        }

        public Question CreateNewQuestion(string questionTitle)
        {
            Question newQuestion = new Question((uint)_gameConfiguration.numberOfAnswers, questionTitle);
            _quiz.AddQuestion(newQuestion);
            return newQuestion;
        }

        public Answer CreateAnswer()
        {
            return new Answer();
        }
    }
}
