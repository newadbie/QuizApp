using System;
using QuizApp.Exceptions;
using QuizApp.Interfaces;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionNewQuiz : MenuOption
    {
        private readonly MenuView _menuView;
        private readonly GameConfiguration _gameConfiguration;
        private Quiz _newQuiz;

        public MenuOptionNewQuiz(MenuView menuView,
            GameConfiguration gameConfiguration,
            IApplication applicationController) : base(applicationController)
        {
            _menuView = menuView;
            _gameConfiguration = gameConfiguration;
        }

        public override void Action()
        {
            _menuView.GiveQuizName();
            string quizName = Console.ReadLine();
            _newQuiz = Quiz.Create(quizName);
            Console.Clear();

            CreateQuestions();
        }

        private void CreateQuestions()
        {
            _menuView.HowManyQuestions();
            try
            {
                int input = Console.ReadLine().ParseInRange(0, _gameConfiguration.MaxQuestions);
                Console.Clear();
                for (int i = 0; i < input; i++)
                {
                    _menuView.AskForQuestion(i + 1);
                    string questionTitle = Console.ReadLine();
                    var question = Question.Create(questionTitle);
                    _newQuiz.AddQuestion(question);
                    Console.Clear();
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
