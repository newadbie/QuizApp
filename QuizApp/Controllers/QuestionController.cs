using System;
using System.Collections.Generic;
using QuizApp.Exceptions;
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
            return new Answer(Console.ReadLine());
        }

        public List<Answer> SelectCorrectAnswer(List<Answer> answers)
        {
            if (!int.TryParse(Console.ReadLine(), out int selectOpt) 
                || selectOpt - 1 > answers.Count 
                || selectOpt - 1 < 0)
            {
                throw new IncorrectInputException();
            }

            answers[selectOpt - 1].IsCorrect = true;
            return answers;
        }
    }
}
