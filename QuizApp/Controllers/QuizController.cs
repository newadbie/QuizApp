using System;
using QuizApp.Services;

namespace QuizApp.Controllers
{
    public class QuizController
    {
        private readonly MenuService _menuService = new MenuService();

        public void Menu()
        {
            _menuService.MenuSelect();
        }
    }
}
