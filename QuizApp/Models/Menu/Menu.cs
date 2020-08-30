using System;
using System.Collections.Generic;
using System.Text;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class Menu
    {
        private readonly Dictionary<string, IMenuOption> _options = new Dictionary<string, IMenuOption>();
        public Dictionary<string, IMenuOption> GetOptions() => _options;

        public Menu(CreateView createView, GameConfiguration gameConfiguration)
        {
            _options.Add("Exit", new MenuOptionExit());
            _options.Add("New quiz", new MenuOptionNewQuiz(createView, gameConfiguration));
        }

    }
}
