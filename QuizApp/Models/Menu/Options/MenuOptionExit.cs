using System;
using System.Threading.Tasks;
using QuizApp.Controllers;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionExit : MenuOption
    {
        public override void Action()
        {
            _menu.ExitApplication();
        }

        public MenuOptionExit(Menu menu) : base(menu)
        {
        }
    }
}
