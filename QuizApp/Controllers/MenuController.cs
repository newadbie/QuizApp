using System;
using System.Linq;
using QuizApp.Models.Menu;
using QuizApp.Validators;
using QuizApp.Views;
using QuizApp.Views.Menu;

namespace QuizApp.Controllers
{
    public class MenuController
    {
        private readonly Menu _menu;
        private readonly MenuView _menuView;

        public MenuController(
            Menu menu,
            MenuView menuView)
        {
            _menu = menu;
            _menuView = menuView;
        }

        public void ShowMenu()
        {
            _menuView.ShowMenu(_menu.GetOptions());
        }

        public IMenuOption SelectMenuOption()
        {
            int input = Console.ReadLine().SelectIntParse(_menu.GetOptions().Count);

            var menuOptions = _menu.GetOptions().Select(x => x.Value).ToList();

            var selectedOption = menuOptions[input - 1];

            return selectedOption;
        }
    }
}
