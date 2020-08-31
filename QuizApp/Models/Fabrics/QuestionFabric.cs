using System;
using QuizApp.Validators;

namespace QuizApp.Models
{
    public partial class Question
    {
        public static Question Create(string title)
        {
            if (!title.IsTitleCorrect())
            {
                throw new Exception("Title is incorrect");
            }
            
            return new Question(title);
        }
    }
}
