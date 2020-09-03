using QuizApp.Controllers;
using QuizApp.Interfaces;
using QuizApp.Models.Menu.Interfaces;

namespace QuizApp.Models.Menu.Options
{
    public abstract  class MenuOption : IMenuOption
    {
        protected readonly Menu _menu;

        protected MenuOption(Menu menu)
        {
            _menu = menu;
        }

        public abstract void Action();
    }
}
