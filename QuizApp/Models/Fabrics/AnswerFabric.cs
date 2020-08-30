using System;
using QuizApp.Validators;

namespace QuizApp.Models
{
    public partial class Answer
    {
        public Answer Create(string title)
        {
            if (!title.IsTitleCorrect())
            {
                throw new Exception("Title is incorrect");
            }

            return new Answer(title);
        }
    }
}
