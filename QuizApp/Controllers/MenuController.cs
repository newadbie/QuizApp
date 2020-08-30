using System;
using QuizApp.Validators;
using System.Linq;
using QuizApp.Models;
using QuizApp.Models.Menu;
using QuizApp.Views;

namespace QuizApp.Controllers
{
    public class MenuController
    {
        private readonly MenuView _menuView;
        private readonly GameConfiguration _gameConfiguration;
        private readonly Menu _menu;

        public MenuController(MenuView menuView, GameConfiguration gameConfiguration, Menu menu)
        {
            _menuView = menuView;
            _gameConfiguration = gameConfiguration;
            _menu = menu;
        }

        public IMenuOption MenuAction()
        {
            _menuView.ShowMenu();
            return SelectOption();
        }

        private IMenuOption SelectOption()
        {
            int input = Console.ReadLine().SelectIntParse(_menu.GetOptions().Count);

            var menuOptions = _menu.GetOptions().Select(x => x.Value).ToList();
            return menuOptions[input - 1];
        }
    }
}
