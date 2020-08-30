using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models.Menu
{
    public class Menu
    {
        private List<IMenuOption> _options  = new List<IMenuOption>()
        {
            new MenuOptionExit(),
            new MenuOptionNewQuiz()
        };

        public List<IMenuOption> GetOptions() => _options;
    }
}
