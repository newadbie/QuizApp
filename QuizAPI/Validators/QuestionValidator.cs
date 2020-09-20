using System;
using System.Collections.Generic;
using System.Linq;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuestionValidator : ValidatorWithOptions<Question>
    {
        private readonly TextValidator _questionTitleValidator;
        public override List<string> ValidationErrors { get; protected set; } = new List<string>();

        public QuestionValidator(List<Option> options) : base(options)
        {
            try
            {
                int minQuestionTitleLength = options
                    .Where(x => x.Name == "MinQuestionTitleLength")
                    .Select(x => x.IntValue)
                    .First();

                int maxQuestionTitleLength = options
                    .Where(x => x.Name == "MaxQuestionTitleLength")
                    .Select(x => x.IntValue)
                    .First();

                _questionTitleValidator = TextValidator.Create(minQuestionTitleLength, maxQuestionTitleLength);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Used options doesn't exist");
            }

        }

        public override bool Validate(Question question)
        {
            if (!_questionTitleValidator.Validate(question.Title))
            {
                ValidationErrors.AddRange(_questionTitleValidator.ValidationErrors);
            }

            ValidateAnswers(question.Answers);

            return !ValidationErrors.Any();
        }

        private bool ValidateAnswers(List<Answer> answers)
        {
            var answersNumber = Options.Where(o => o.Name == "NumberOfAnswers")
                .Select(v => v.IntValue).FirstOrDefault();

            if (answers == null || answers.Count == 0)
            {
                ValidationErrors.Add("No answers created!");
                return false;
            }

            if (answers.Count != answersNumber)
            {
                ValidationErrors.Add("Incorrect number of answers");
                return false;
            }

            if (answers.Count(answer => answer.IsCorrect) != 1)
            {
                ValidationErrors.Add("Incorrect selected answers number!");
                return false;
            }

            return true;
        }

    }
}
