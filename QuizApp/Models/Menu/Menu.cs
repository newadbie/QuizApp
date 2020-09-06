using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Interfaces;
using QuizApp.Models.Menu.Interfaces;
using QuizApp.Models.Menu.Options;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class Menu : IMenu
    {
        private readonly MenuView _menuView;
        private readonly GameConfiguration _gameConfiguration;
        private readonly IDatabase _db;
        private readonly ITasksService _tasksService;
        public List<IMenuOption> Options { get; } = new List<IMenuOption>();


        public bool Exit { get; private set; } = false;
        public List<string> Headers { get; } = new List<string>() { "Hello in my quiz application!", "Select what would you like to do!"};

        public Menu(
            MenuView menuView,
            GameConfiguration gameConfiguration,
            IDatabase db
            )
        {
            _gameConfiguration = gameConfiguration;
            _menuView = menuView;
            _db = db;
            _tasksService = SingletonTasksService.GetTasksService();

            AddMenuOptions();
        }

        private void AddMenuOptions()
        {
            Options.Add(new MenuOption() {Text = "Exit", Action = ExitApplication});
            Options.Add(new MenuOption() { Text = "New quiz", Action = CreateNewQuiz });
            Options.Add(new MenuOption() { Text = "Reply to created quiz", Action = () => throw new NotImplementedException() });
        }

        private void CreateNewQuiz()
        {
            _menuView.GiveQuizName();
            string quizName = Console.ReadLine();
            Quiz newQuiz = Quiz.Create(quizName);
            Console.Clear();

            newQuiz = Question.CreateQuestions(newQuiz, _menuView, _gameConfiguration);

            if (newQuiz.HasQuestions())
            {
                _tasksService.AddTask(_db.SaveQuiz(newQuiz));
            }
        }

        public IMenuOption SelectMenuOption()
        {
            if (!Console.ReadLine().SelectIntParse(Options.Count, out int input))
            {
                Console.WriteLine("Incorrect input!");
                return null;
            }

            IMenuOption selectedOption = Options[input - 1];
            return selectedOption;
        }

        private void ExitApplication()
        {
            Exit = true;
        }
    }
}
