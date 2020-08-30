using System;
using QuizApp.Exceptions;
using QuizApp.Validators;

namespace QuizApp.Models
{
    public partial class Question
    {
        public Question Create(string title, uint numberOfAnswers)
        {
            if (!title.IsTitleCorrect())
            {
                throw new Exception("Title is incorrect");
            }
            
            return new Question(title, numberOfAnswers);
        }
    }
}
