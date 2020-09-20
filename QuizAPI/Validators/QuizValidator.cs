using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuizValidator : IValidator<Quiz>
    {
        public IEnumerable<string> ValidationErrors { get; } // Todo create as dictionary saved in the database

        public bool Validate(Quiz quiz)
        {
            List<string> validationErrors = new List<string>();
            var quizTitleValidator = TextValidator.Create(1, 10);

            if (!quizTitleValidator.Validate(quiz.Title))
            {
                validationErrors.AddRange(quizTitleValidator.ValidationErrors);
            }


            return true;
        }
    }
}
