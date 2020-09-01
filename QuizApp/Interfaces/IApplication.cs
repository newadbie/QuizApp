using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.Interfaces
{
    public interface IApplication
    {
        ApplicationContext GetContext();
        List<Quiz> GetQuizzes();
        int GetMaxNumberOfQuestions();
        int GetNumberOfAnswers();
        void AddQuiz(Quiz quizToAdd);
        int GetNumberOfQuizzes();
    }
}
