using System;
using QuizApp.Controllers;
using QuizApp.Views;

namespace QuizApp.Models.Menu
{
    public class MenuOptionExit : MenuOption
    {
        public override void Action()
        {
            Environment.Exit(1);
        }

        public MenuOptionExit(ApplicationController applicationController) : base(applicationController)
        {
        }
    }
}
