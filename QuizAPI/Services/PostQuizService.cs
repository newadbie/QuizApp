using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;
using QuizAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Services
{
    public class PostQuizService
    {
        private readonly QuizContext _context;
        private readonly PostQuiz _postQuizModel;

        public PostQuizService(QuizContext context, PostQuiz postQuiz)
        {
            _context = context;
            _postQuizModel = postQuiz;
        }

        public async Task<bool> PostQuiz()
        {
            if (!_postQuizModel.IsValid()) return false;

            var quiz = _postQuizModel.Quiz;

            _context.Quizzes.Add(quiz);

            if (!ValidateQuiz(quiz)
                || !PutCorrectAnswers(quiz.Questions, _postQuizModel.CorrectAnswersInQuestion))
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private bool ValidateQuiz(Quiz quiz)
        {
            try
            {
                var options = _context.Options.ToList();
                QuizValidator quizValidator = new QuizValidator(options);

                if (!quizValidator.Validate(quiz))
                {
                    foreach (var error in quizValidator.ValidationErrors)
                    {
                        Console.WriteLine(error);
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        private bool PutCorrectAnswers(List<Question> questions, Dictionary<int, int> correctAnswerInQuestion)
        {
            foreach (var item in correctAnswerInQuestion)
            {
                if (questions[item.Key] != null
                    && questions[item.Key].Answers[item.Value] != null)
                {
                    var correctAnswer = new CorrectAnswer()
                    {
                        Answer = questions[item.Key].Answers[item.Value]
                    };
                    _context.CorrectAnswers.Add(correctAnswer);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
