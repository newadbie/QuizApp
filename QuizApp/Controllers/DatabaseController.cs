using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class DatabaseController : IDatabase
    {
        private List<Quiz> quizzes;
        public async Task SaveQuiz(Quiz quizToSave)
        {
            await using ApplicationContext applicationContext = new ApplicationContext();
            applicationContext.Add(quizToSave);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<Quiz>> GetQuizzes()
        {
            await using ApplicationContext applicationContext = new ApplicationContext();
            quizzes = applicationContext.Quizzes
                .Include(b => b.Questions)
                .ThenInclude(a => a.Answers).ToList();

            return quizzes;
        }

        public Task LoadQuizzes()
        {
            throw new NotImplementedException();
        }
    }
}
