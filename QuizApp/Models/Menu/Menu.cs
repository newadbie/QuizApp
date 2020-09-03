using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Exceptions;
using QuizApp.Models.Menu.Interfaces;
using QuizApp.Models.Menu.Options;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class Menu
    {
        private readonly MenuView _menuView;
        private readonly GameConfiguration _gameConfiguration;
        private readonly Dictionary<string, IMenuOption> _options = new Dictionary<string, IMenuOption>();

        public Dictionary<string, IMenuOption> GetOptions() => _options;

        public Menu(
            MenuView menuView,
            GameConfiguration gameConfiguration
            )
        {
            _gameConfiguration = gameConfiguration;
            _menuView = menuView;

            _options.Add("Exit", new MenuOptionExit(this));
            _options.Add("New quiz", new MenuOptionNewQuiz(this));
            _options.Add("Reply to created quiz", new MenuOptionReplyTo(this));
        }

        public void ShowMenu()
        {
            _menuView.ShowMenu(_options);
        }

        public void CreateNewQuiz()
        {
            _menuView.GiveQuizName();
            string quizName = Console.ReadLine();
            var newQuiz = Quiz.Create(quizName);
            Console.Clear();

            CreateQuestions(newQuiz);
        }

        private void CreateQuestions(Quiz newQuiz)
        {
            _menuView.HowManyQuestions();
            try
            {
                int maxNumberOfQuestions = _gameConfiguration.MaxQuestions;

                int input = Console.ReadLine().ParseInRange(0, maxNumberOfQuestions);
                Console.Clear();
                for (int i = 0; i < input; i++)
                {
                    _menuView.AskForQuestion(i + 1);
                    string questionTitle = Console.ReadLine();
                    var question = Question.Create(questionTitle);
                    Console.Clear();
                    CreateAnswers(question);
                    SelectCorrectAnswer(question);

                    newQuiz.AddQuestion(question);
                    Console.Clear();
                }
            }
            catch (IncorrectInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateAnswers(Question currentQuestion)
        {
            int numberOfAnswers = _gameConfiguration.NumberOfAnswers;
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.Clear();
                _menuView.AskForAnswer(i + 1);
                var newAnswer = Answer.Create(Console.ReadLine());
                currentQuestion.AddAnswer(newAnswer);
            }
        }

        private void SelectCorrectAnswer(Question currentQuestion)
        {
            Console.Clear();
            var answers = currentQuestion.Answers;
            var answersTitle = answers.Select(x => x.Title).ToList();
            _menuView.ShowAnswers(answersTitle);

            var correctAnswer = Console.ReadLine().SelectIntParse(answersTitle.Count);
            if (correctAnswer != -1)
            {
                answers[correctAnswer - 1].IsCorrect = true;
            }
            else
            {
                throw new Exception("Incorrect");
            }
        }

        public IMenuOption SelectMenuOption()
        {
            int input = Console.ReadLine().SelectIntParse(GetOptions().Count);

            var menuOptions = GetOptions().Select(x => x.Value).ToList();

            var selectedOption = menuOptions[input - 1];

            return selectedOption;
        }
    }
}
