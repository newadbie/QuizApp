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

            Assert.IsFalse(_questionValidator.Validate(testQuestion));
        }

        [Test]
        public void QuestionValidate_IncorrectNumberOfAnswers_ShouldReturn_False()
        {
            var testQuestion = new Question();
            testQuestion.Quiz = _testQuiz;
            testQuestion.Answers = new List<Answer>();
            testQuestion.Title = "Correct";
            testQuestion.Answers.Add(new Answer() {Title = "Correct title"});

            Assert.IsFalse(_questionValidator.Validate(testQuestion));
        }

        [TestCase("My name is a Adrian")]
        [TestCase("My name is A Adrian")]
        [TestCase("Random d")]
        [TestCase("Random D")]
        [TestCase("It is illegal Word")]
        [TestCase("It is illegal word")]
        [Test]
        public void TextValidate_ForbiddenWord_ShouldReturn_False(string value)
        {
            List<string> forbiddenWords = new List<string>() {"a", "b", "c", "d", "Word", "ill"};
            TextValidator textValidator = new TextValidator(1,50, forbiddenWords);

            Assert.IsFalse(textValidator.Validate(value));
        }
    }

}
