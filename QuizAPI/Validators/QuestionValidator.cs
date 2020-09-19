using System.Collections.Generic;
using System.Linq;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuestionValidator : IValidator<Question>
    {
        public IEnumerable<string> ValidationErrors { get; private set; }
        public bool Validate(Question question)
        {
            List<string> validationErrors = new List<string>();

            if (question.Answers.Count == 0)
            {
                validationErrors.Add("No answers created!");
            }

            if (question.Answers.Count(answer => answer.IsCorrect) != 1)
            {
                validationErrors.Add("Incorrect selected answers number!");
            }
            if (string.IsNullOrWhiteSpace(question.Title))
            {
                validationErrors.Add("Title is empty");
            }

            ValidationErrors = validationErrors;

            return !ValidationErrors.Any();
        }

    }
}
