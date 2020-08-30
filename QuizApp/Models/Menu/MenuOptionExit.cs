using System;

namespace QuizApp.Models.Menu
{
    public class MenuOptionExit : IMenuOption
    {
        public void Action()
        {
            Environment.Exit(1);
        }
    }
}
