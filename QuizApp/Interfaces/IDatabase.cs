using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IDatabase
    {
        Task SaveQuiz(Quiz quizToSave);

        Task<List<Quiz>> GetQuizzes();

        Task LoadQuizzes();
    }
}
