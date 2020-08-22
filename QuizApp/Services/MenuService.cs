using System;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class MenuService
    {
        public void MenuSelect()
        {
            if (!int.TryParse(Console.ReadLine(), out int opt) 
            || Enum.GetName(typeof(EMenuOptions), opt) == null)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine("Correct!");
            }
        }
    }
}
