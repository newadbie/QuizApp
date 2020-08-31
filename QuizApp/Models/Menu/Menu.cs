using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models.Menu.Options;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class Menu 
    {
        //private readonly IMenuView _menuView;
        private readonly Dictionary<string, IMenuOption> _options = new Dictionary<string, IMenuOption>();

        public Dictionary<string, IMenuOption> GetOptions() => _options;

        public Menu(
            GameConfiguration gameConfiguration,
            IApplication application,
            MenuView menuView
            )
        {
            _options.Add("Exit", new MenuOptionExit(application));
            _options.Add("New quiz", new MenuOptionNewQuiz(menuView, gameConfiguration, application));
        }
    }
}
