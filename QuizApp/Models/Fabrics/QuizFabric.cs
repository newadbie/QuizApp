using System;
using QuizApp.Validators;

namespace QuizApp.Models
{
    public partial class Quiz
    {
        public Quiz Create(string title)
        {
            if (!title.IsTitleCorrect())
            {
                throw new Exception("Incorrect title!");
            }
            return new Quiz(title);
        }
    }
}
