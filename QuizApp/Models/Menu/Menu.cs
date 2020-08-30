using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models.Menu
{
    public class Menu
    {
        private readonly Dictionary<string, IMenuOption> _options  = new Dictionary<string,IMenuOption>()
        {
            { "Exit", new MenuOptionExit()},
            { "New quiz", new MenuOptionNewQuiz() }
        };

        public Dictionary<string, IMenuOption> GetOptions() => _options;
    }
}
