using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuizValidator : ValidatorWithOptions<Quiz>
    {
        public QuizValidator(List<Option> options) : base(options) {}

        public override List<string> ValidationErrors { get; protected set; }

        public override bool Validate(Quiz quiz)
        {
            if (Options == null || Options.Count == 0)
            {
                throw new Exception("You forget about options!");
            }

            int minTitleLength = Options.Where(x => x.Name == "MinQuizTitleLength")
                .Select(x => x.IntValue).FirstOrDefault();
            int maxTitleLength = Options.Where(x => x.Name == "MaxQuizTitleLength")
                .Select(x => x.IntValue).FirstOrDefault();

            List<string> validationErrors = new List<string>();
            var quizTitleValidator = TextValidator.Create(minTitleLength, maxTitleLength);

            if (!quizTitleValidator.Validate(quiz.Title))
            {
                validationErrors.AddRange(quizTitleValidator.ValidationErrors);
            }

            return true;
        }
    }
}
