using System;
using System.Linq;
using QuizApp.Controllers;
using QuizApp.Exceptions;
using QuizApp.Interfaces;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionNewQuiz : MenuOption
    {
        public MenuOptionNewQuiz(Menu menu) : base(menu)
        {
        }

        public override void Action()
        {
            _menu.CreateNewQuiz();
        }
    }
}
