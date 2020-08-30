using System;
using System.Collections.Generic;
using QuizApp.Controllers;
using QuizApp.Exceptions;
using QuizApp.Models;
using QuizApp.Models.Menu;

namespace QuizApp.Views
{
    public class QuizView
    {
        private readonly Menu _menu;

        public QuizView(Menu menu)
        {
            _menu = menu;
        }

        public void Elo()
        {
            Console.WriteLine(_menu.GetOptions().Count);
            Console.WriteLine("Elo");
        }
    }
}
