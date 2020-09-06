using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models.Menu.Interfaces
{
    public interface IMenu
    {
        List<string> Headers { get; }
        List<IMenuOption> Options { get; }
    }
}
