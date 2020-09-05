using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class DatabaseController : IDatabase
    {
        public async Task SaveQuiz(Quiz quizToSave)
        {
            await using var applicationContext = new ApplicationContext();
            applicationContext.Add(quizToSave);
            await applicationContext.SaveChangesAsync();
            await applicationContext.DisposeAsync();
        }

        public List<Quiz> GetQuizzes()
        {
            throw new NotImplementedException();
        }

        public Task LoadQuizzes()
        {
            throw new NotImplementedException();
        }
    }
}
