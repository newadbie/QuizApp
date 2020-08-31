using System;
using QuizApp.Exceptions;
using QuizApp.Interfaces;
using QuizApp.Validators;
using QuizApp.Views;
using QuizApp.Views.Interfaces;

namespace QuizApp.Models.Menu
{
    public class MenuOptionNewQuiz : MenuOption
    {
        private readonly ICreate _createView;
        private readonly GameConfiguration _gameConfiguration;
        private Quiz _newQuiz;

        public MenuOptionNewQuiz(ICreate createView,
            GameConfiguration gameConfiguration,
            IApplication applicationController) : base(applicationController)
        {
            _createView = createView;
            _gameConfiguration = gameConfiguration;
        }

        public override void Action()
        {
            _createView.GiveQuizName();
            string quizName = Console.ReadLine();
            _newQuiz = Quiz.Create(quizName);

            CreateQuestions();
        }

        private void CreateQuestions()
        {
            _createView.HowManyQuestions();
            try
            {
                int input = Console.ReadLine().ParseInRange(0, _gameConfiguration.MaxQuestions);
                for (int i = 0; i < input; i++)
                {
                    _createView.AskForQuestion(i + 1);
                    string questionTitle = Console.ReadLine();
                    var question = Question.Create(questionTitle);
                    _newQuiz.AddQuestion(question);
                }
                ImplementNewQuizToApplication();
            }
            catch (IncorrectInputException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ImplementNewQuizToApplication()
        {
            Application.AddQuiz(_newQuiz);
        }
    }
}
