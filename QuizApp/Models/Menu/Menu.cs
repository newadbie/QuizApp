using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Views.Interfaces;

namespace QuizApp.Models.Menu
{
    public class Menu
    {
        private readonly Dictionary<string, IMenuOption> _options = new Dictionary<string, IMenuOption>();
        public Dictionary<string, IMenuOption> GetOptions() => _options;

        public Menu(ICreate createView,
            GameConfiguration gameConfiguration,
            IApplication application)
        {
            _options.Add("Exit", new MenuOptionExit(application));
            _options.Add("New quiz", new MenuOptionNewQuiz(createView, gameConfiguration, application));
        }

    }
}
