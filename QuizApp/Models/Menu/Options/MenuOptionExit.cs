using System;
using QuizApp.Controllers;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionExit : MenuOption
    {
        public override void Action()
        {
            Environment.Exit(1);
        }

        public MenuOptionExit(Menu menu) : base(menu)
        {
        }
    }
}
