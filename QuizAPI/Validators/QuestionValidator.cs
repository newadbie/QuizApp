using System.Collections.Generic;
using System.Linq;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuestionValidator : IValidator<Question>
    {
        private readonly TextValidator _textValidator;
        public IEnumerable<string> ValidationErrors { get; private set; }

        public QuestionValidator(int minTitleLength, int maxTitleLength)
        {
            _textValidator = TextValidator.Create(minTitleLength, maxTitleLength);
        }

        public bool Validate(Question question)
        {
            List<string> validationErrors = new List<string>();

            if (question.Answers == null || question.Answers.Count == 0)
            {
                validationErrors.Add("No answers created!");
                return false;
            }

            if (question.Answers.Count != 4) // TODO remove magic number
            {
                validationErrors.Add("Incorrect number of answers");
            }

            if (question.Answers.Count(answer => answer.IsCorrect) != 1)
            {
                validationErrors.Add("Incorrect selected answers number!");
            }

            if (!_textValidator.Validate(question.Title ?? ""))
            {
                validationErrors.AddRange(_textValidator.ValidationErrors);
            }

            ValidationErrors = validationErrors;

            return !ValidationErrors.Any();
        }

    }
}
