using System;
using System.Collections.Generic;
using System.Text;
using QuizApp.Models.Menu;

namespace QuizApp.Views
{
    public class MenuView
    {
        private readonly Menu _menu;

        public MenuView(Menu menu)
        {
            _menu = menu;
        }
        public void ShowMenu()
        {
            Console.WriteLine("Hello in my quiz application!");
            Console.WriteLine("Select what would you like to do!");
             
            int i = 1;
            foreach (var option in _menu.GetOptions())
            {
                Console.WriteLine($"{i++}. {option.Key}");
            }

            Console.WriteLine("Make your choice!");
        }
    }
}
