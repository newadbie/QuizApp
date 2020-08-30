using System;
using System.Collections.Generic;
using System.Text;
using QuizApp.Controllers;

namespace QuizApp.Models.Menu
{
    public abstract  class MenuOption : IMenuOption
    {
        protected readonly ApplicationController _applicationController;

        protected MenuOption(ApplicationController applicationController)
        {
            _applicationController = applicationController;
        }

        public abstract void Action();
    }
}
