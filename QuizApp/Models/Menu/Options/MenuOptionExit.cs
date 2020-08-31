using System;
using QuizApp.Controllers;
using QuizApp.Interfaces;
using QuizApp.Views;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionExit : MenuOption
    {
        public override void Action()
        {
            Environment.Exit(1);
        }

        public MenuOptionExit(IApplication application) : base(application)
        {
        }
    }
}
