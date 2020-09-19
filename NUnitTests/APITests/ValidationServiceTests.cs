using System.Collections.Generic;
using NUnit.Framework;
using QuizAPI.Models;
using QuizAPI.Validators;

namespace NUnitTests.APITests
{
    [TestFixture]
    public class ValidationServiceTests
    {
        private  QuestionValidator _questionValidator;
        public Quiz _testQuiz;

        [SetUp]
        public void SetUp()
        {
            _questionValidator = new QuestionValidator();
            _testQuiz = new Quiz {Title = "BLEB", Id =  1};
        }

        [Test]
        public void QuestionValidate_NoAnswers_ShouldReturn_False()
        {
            var testQuestion = new Question();
            testQuestion.Quiz = _testQuiz;
            testQuestion.Answers = new List<Answer>();
            testQuestion.Title = "Correct";

            Assert.False(_questionValidator.Validate(testQuestion));
        }

        [Test]
        public void QuestionValidate_IncorrectNumberOfAnswers_ShouldReturn_False()
        {
            var testQuestion = new Question();
            testQuestion.Quiz = _testQuiz;
            testQuestion.Answers = new List<Answer>();
            testQuestion.Title = "Correct";
            testQuestion.Answers.Add(new Answer() {Title = "Correct title"});

            Assert.False(_questionValidator.Validate(testQuestion));
        }
    }

}
