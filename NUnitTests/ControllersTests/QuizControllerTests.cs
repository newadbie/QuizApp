using System;
using NUnit.Framework;
using QuizApp.Exceptions;
using QuizApp.Models;

namespace NUnitTests.ControllersTests
{
    [TestFixture]
    public class QuizControllerTests
    {
        private Quiz _quiz;

        [SetUp]
        public void Init()
        {
            _quiz = new Quiz("Example quiz");
        }

        [Test]
        public void Quiz_Constructor_0LengthTitle_Should_Throw_IncorrectInputException()
        {
            Assert.Throws<IncorrectInputException>(() => new Quiz(""));
        }

        [Test]
        public void Quiz_Constructor_Correct()
        {
            Assert.DoesNotThrow(() => new Quiz("Correct title"));
        }

        [Test]
        public void Quiz_GetQuestions_When_QuestionsNotExists_Should_Throw_OutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _quiz.GetQuestions());
        }

        [Test]
        public void Quiz_GetQuestions_Correct()
        {
            Question questionToAdd = new Question(4,"Tytuł");
            _quiz.AddQuestion(questionToAdd);
            Assert.DoesNotThrow(() => _quiz.GetQuestions());
        }
    }
}
