using System;
using System.Collections.Generic;
using QuizApp.Models;
using QuizApp.Models.Menu;

namespace QuizApp.Controllers
{
    public class ApplicationController
    {
        private List<Quiz> quizzes { get; set; } = new List<Quiz>();

        public List<Quiz> GetQuizzes() => quizzes;

        public void AddQuiz(Quiz quizToAdd)
        {
            quizzes.Add(quizToAdd);
        }
    }
}
