using System;
using System.Collections.Generic;
using System.Linq;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuizValidator : ValidatorWithOptions<Quiz>
    {
        public QuizValidator(List<Option> options) : base(options) {}

        public override List<string> ValidationErrors { get; protected set; } = new List<string>();

        public override bool Validate(Quiz quiz)
        {
            if (Options == null || Options.Count == 0)
            {
                throw new Exception("You forget about options!");
            }

            ValidateMetaQuiz(quiz);

            ValidateQuestions(quiz.Questions);

            return !ValidationErrors.Any();
        }

        private void ValidateMetaQuiz(Quiz quiz)
        {
            int minTitleLength = Options
                .Where(x => x.Name == "MinQuizTitleLength")
                .Select(x => x.IntValue).FirstOrDefault();

            int maxTitleLength = Options
                .Where(x => x.Name == "MaxQuizTitleLength")
                .Select(x => x.IntValue).FirstOrDefault();

            var quizTitleValidator = TextValidator.Create(minTitleLength, maxTitleLength);

            if (!quizTitleValidator.Validate(quiz.Title))
            {
                ValidationErrors.AddRange(quizTitleValidator.ValidationErrors);
            }
        }

        private void ValidateQuestions(List<Question> questions)
        {

            foreach (var question in questions)
            {
                var questionValidator = new QuestionValidator(Options);
                if (!questionValidator.Validate(question))
                {
                    ValidationErrors.AddRange(questionValidator.ValidationErrors);
                }
            }
        }
    }
}
