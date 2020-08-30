using QuizApp.Models.Menu;

namespace QuizApp.Controllers
{
    public class ApplicationController
    {
        private readonly MenuController _menuController;
        private  IMenuOption _selectedOption;

        public ApplicationController(MenuController menuController)
        {
            _menuController = menuController;
        }

        public void StartGame()
        {
            _selectedOption = _menuController.MenuAction();
            _selectedOption.Action();
        }
    }
}
