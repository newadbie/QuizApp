using System;

namespace QuizApp.Models.Menu.Interfaces
{
    public interface IMenuOption
    {
        string Text { get; set; }
        Action Action { get; set; }
    }
}
