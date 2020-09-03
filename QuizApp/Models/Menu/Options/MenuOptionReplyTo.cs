using System;
using QuizApp.Controllers;
using QuizApp.Interfaces;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionReplyTo : MenuOption
    {
        public override void Action()
        {
            throw new NotImplementedException();
        }

        public MenuOptionReplyTo(Menu menu) : base(menu) { }
    }
}
