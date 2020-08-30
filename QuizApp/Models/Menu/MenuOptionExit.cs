using System;

namespace QuizApp.Models.Menu
{
    public class MenuOptionExit : IMenuOption
    {
        public void Action()
        {
            Console.WriteLine("Exit!");
            //Environment.Exit(1);
        }
    }
}
