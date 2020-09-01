using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models.Menu.Interfaces;
using QuizApp.Models.Menu.Options;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class Menu 
    {
        private readonly Dictionary<string, IMenuOption> _options = new Dictionary<string, IMenuOption>();

        public Dictionary<string, IMenuOption> GetOptions() => _options;

        public Menu(
            IApplication application,
            MenuView menuView
            )
        {
            _options.Add("Exit", new MenuOptionExit(application));
            _options.Add("New quiz", new MenuOptionNewQuiz(menuView, application));
        }
    }
}
