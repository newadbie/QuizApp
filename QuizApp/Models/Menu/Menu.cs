using System;
using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models.Builders;
using QuizApp.Models.Menu.Interfaces;
using QuizApp.Models.Menu.Options;
using QuizApp.Services;
using QuizApp.Validators;

namespace QuizApp.Models.Menu
{
    public class Menu : IMenu
    {
        private readonly GameConfiguration _gameConfiguration;
        private readonly IDatabase _db;
        private readonly ITasksService _tasksService;
        private readonly QuestionBuilder _questionBuilder;
        private readonly ReplyForService _replyForService;

        public List<IMenuOption> Options { get; } = new List<IMenuOption>();

        public bool Exit { get; private set; } = false;

        public List<string> Headers { get; } = new List<string>() { "Hello in my quiz application!", "Select what would you like to do!"};

        public Menu(
            GameConfiguration gameConfiguration,
            IDatabase db,
            QuestionBuilder questionBuilder,
            ITasksService tasksService,
            ReplyForService replyForService
            )
        {
            _gameConfiguration = gameConfiguration;
            _db = db;
            _tasksService = tasksService;
            _questionBuilder = questionBuilder;
            _replyForService = replyForService;

            AddMenuOptions();
        }

        private void AddMenuOptions()
        {
            Options.Add(new MenuOption() {Text = "Exit", Action = ExitApplication});
            Options.Add(new MenuOption() { Text = "New quiz", Action = CreateNewQuiz });
            Options.Add(new MenuOption() { Text = "Reply to created quiz", Action = _replyForService.SelectQuiz });
        }

        private void CreateNewQuiz()
        {
            Console.WriteLine("Give title for your new quiz!");
            string quizName = Console.ReadLine();
            TitleValidator titleValidator = new TitleValidator();

            while (true)
            {
                if (titleValidator.Validate(quizName))
                {
                    Quiz newQuiz = new Quiz(quizName);
                    Console.Clear();

                    _questionBuilder.CreateQuestions(newQuiz);

                    if (newQuiz.HasQuestions())
                    {
                        _tasksService.AddTask(_db.SaveQuiz(newQuiz));
                        _tasksService.AddTask(_replyForService.LoadQuizzes());
                    }

                    break;
                }
            }
        }

        public IMenuOption SelectMenuOption(int selection)
        {
            if (selection < 1 || selection > Options.Count) return null;
            return Options[selection - 1];
        }

        private void ExitApplication()
        {
            Exit = true;
        }
    }
}
