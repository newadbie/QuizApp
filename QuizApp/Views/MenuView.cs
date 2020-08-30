using System;
using System.Collections.Generic;
using System.Text;
using QuizApp.Models.Menu;

namespace QuizApp.Views
{
    public class MenuView
    {
        public void ShowMenu(Dictionary<string, IMenuOption> menuOptions)
        {
            Console.WriteLine("Hello in my quiz application!");
            Console.WriteLine("Select what would you like to do!");
             
            int i = 1;
            foreach (var option in menuOptions)
            {
                Console.WriteLine($"{i++}. {option.Key}");
            }

            Console.WriteLine("Make your choice!");
        }
    }
}
