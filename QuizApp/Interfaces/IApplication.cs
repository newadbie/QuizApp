using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IApplication
    {
        List<Quiz> GetQuizzes();
        void AddQuiz(Quiz quizToAdd);
        int GetNumberOfQuizzes();
    }
}
