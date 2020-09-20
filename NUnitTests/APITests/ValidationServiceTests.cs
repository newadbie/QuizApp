using System;
using System.Collections.Generic;
using NUnit.Framework;
using QuizAPI.Models;
using QuizAPI.Validators;

namespace NUnitTests.APITests
{
    [TestFixture]
    public class ValidationServiceTests
    {
        private QuestionValidator _questionValidator;

        [SetUp]
        public void SetUp()
        {
            _questionValidator = new QuestionValidator(1, 10);
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
            TextValidator textValidator = TextValidator.Create(1,50, forbiddenWords);

            Assert.IsFalse(textValidator.Validate(value));
        }

        [TestCase("")]
        [TestCase("1")]
        [TestCase("12")]
        [TestCase("123")]
        [TestCase("1234")]
        [TestCase("12345")]
        [TestCase("123456")]
        [TestCase("1234567")]
        [TestCase("12345678")]
        [TestCase("123456789")]
        [Test]
        public void TextValidate_TooShort_ShouldReturn_False(string value)
        {
            TextValidator textValidator = TextValidator.Create(10,100);

            Assert.IsFalse(textValidator.Validate(value));
        }

        [TestCase("My name is a Adrian")]
        [TestCase("My name is A Adrian")]
        [TestCase("Random d")]
        [TestCase("Random D")]
        [TestCase("It is illegal Word")]
        [TestCase("It is illegal word")]
        [Test]
        public void TextValidate_TooLong_ShouldReturn_False(string value)
        {
            TextValidator textValidator = TextValidator.Create(1,2);

            Assert.IsFalse(textValidator.Validate(value));
        }

        [TestCase(1,1)]
        [TestCase(-10,100)]
        [TestCase(0,100)]
        [TestCase(100,100)]
        [TestCase(100,60)]
        [Test]
        public void QuestionValidatorConstructor_Incorrect_MaxMinLength_ShouldThrowException(int minValue, int maxValue)
        {
            Assert.Throws<Exception>(() => new QuestionValidator(minValue, maxValue));
        }

        [TestCase("")]
        [TestCase("12345678910")]
        [Test]
        public void QuestionValidator_TitleTooShort_ShouldReturnFalse(string value)
        {
            var question = new Question {Title = value};

            question.Answers = new List<Answer>()
            {
                new Answer() {Id = 1, IsCorrect = true, Question = question, QuestionId = question.Id, Title = "sd"},
                new Answer() {Id = 2, IsCorrect = false, Question = question, QuestionId = question.Id, Title = "dsa"},
                new Answer() {Id = 3, IsCorrect = false, Question = question, QuestionId = question.Id, Title = "dsaa"},
                new Answer() {Id = 4, IsCorrect = false, Question = question, QuestionId = question.Id, Title = "dsadsa"}
            };

            Assert.IsFalse(_questionValidator.Validate(question));
        }

        [TestCase(1,1)]
        [TestCase(-10,100)]
        [TestCase(0,100)]
        [TestCase(100,100)]
        [TestCase(100,60)]
        [Test]
        public void TextValidate_Incorrect_MaxMinLength_ShouldThrowException(int minValue, int maxValue)
        {
            Assert.Throws<Exception>(() => TextValidator.Create(minValue, maxValue));
        }


        [Test]
        public void QuestionValidate_OneAnswer_ShouldReturnFalse()
        {
            var question = new Question()
            {
               Answers = new List<Answer> {new Answer() {IsCorrect = true, Title = "eee"}},
               Title = "Correct",
            };

            Assert.IsFalse(_questionValidator.Validate(question));
        }

        [Test]
        public void QuestionValidate_NoAnswers_ShouldReturnFalse()
        {
            var question = new Question()
            {
                Answers = new List<Answer>(),
                Title = "Correct",
            };

            Assert.IsFalse(_questionValidator.Validate(question));
        }

        [Test]
        public void QuestionValidate_TooMuchCorrectAnswers_ShouldReturnFalse()
        {
            var question = new Question()
            {
                Answers = new List<Answer>()
                {
                    new Answer() {Id = 1, IsCorrect = false, Title = "dsada"},
                    new Answer() {Id = 2, IsCorrect = true, Title = "dsada"},
                    new Answer() {Id = 3, IsCorrect = true, Title = "dsada"},
                    new Answer() {Id = 4, IsCorrect = false, Title = "dsada"},
                },
                Title = "Correct",
            };

            Assert.IsFalse(_questionValidator.Validate(question));
        }

        [Test]
        public void QuestionValidate_EmptyTitle_ShouldReturnFalse()
        {
            var question = new Question()
            {
                Answers = new List<Answer>()
                {
                    new Answer() {IsCorrect = false},
                    new Answer() {IsCorrect = false},
                    new Answer() {IsCorrect = false},
                    new Answer() {IsCorrect = true}
                },
                Title = null
            };

            Assert.IsFalse(_questionValidator.Validate(question));
        }
    }

}
