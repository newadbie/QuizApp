using System;
using System.Collections.Generic;
using System.Text;
using QuizApp.Controllers;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class Menu
    {
        private readonly Dictionary<string, IMenuOption> _options = new Dictionary<string, IMenuOption>();
        public Dictionary<string, IMenuOption> GetOptions() => _options;

        public Menu(CreateView createView, GameConfiguration gameConfiguration, ApplicationController applicationController)
        {
            _options.Add("Exit", new MenuOptionExit(applicationController));
            _options.Add("New quiz", new MenuOptionNewQuiz(createView, gameConfiguration, applicationController));
        }

    }
}
