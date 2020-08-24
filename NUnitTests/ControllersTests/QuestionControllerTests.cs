using System;
using System.Collections.Generic;
using NUnit.Framework;
using QuizApp.Controllers;
using QuizApp.Exceptions;
using QuizApp.Models;

namespace NUnitTests.ControllersTests
{
    [TestFixture]
    public class QuestionControllerTests
    {
        private Quiz quiz;
        private QuestionController questionController;
        private GameConfiguration gameConfiguration;

        [SetUp]
        public void Init()
        {
            quiz = new Quiz("Bleble");
            gameConfiguration = new GameConfiguration(4,4);
            questionController = new QuestionController(quiz, gameConfiguration);
        }

        [Test]
        public void Question_CreateNewQuestion_0LengthTitle_Should_Throw_IncorrectInputException()
        {
            Assert.Throws<IncorrectInputException>( () => new Question(4, ""));
        }

        [Test]
        public void Question_CreateNewQuestion_Correct()
        {
            Assert.DoesNotThrow(() => new Question(4, "Correct"));
        }

        [Test]
        public void Question_SelectCorrectAnswer_EmptyList_Should_Throw_Exception()
        {
            List<Answer> emptyAnswers = new List<Answer>();
            Assert.Throws<Exception>(() => questionController.SelectCorrectAnswer(emptyAnswers));
        }

        [Test]
        public void Question_SelectCorrectAnswer_TooMuchAnswers_Should_Throw_Exception()
        {
            List<Answer> tooMuchAnswers = new List<Answer>()
            {
                new Answer("First answer"),
                new Answer("Second answer"),
                new Answer("Third answer"),
                new Answer("Fourth answer"),
                new Answer("Five answer")
            };

            Assert.Throws<Exception>(() => questionController.SelectCorrectAnswer(tooMuchAnswers));
        }
    }
}
