using System.Collections.Generic;
using QuizApp.Models.Menu;

namespace QuizApp.Views.Interfaces
{
    public interface IMenu
    {
        void ShowMenu(Dictionary<string, IMenuOption> menuOptions);
    }
}
