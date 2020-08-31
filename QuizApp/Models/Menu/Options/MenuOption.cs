using QuizApp.Interfaces;
using QuizApp.Models.Menu.Interfaces;

namespace QuizApp.Models.Menu.Options
{
    public abstract  class MenuOption : IMenuOption
    {
        protected readonly IApplication Application;

        protected MenuOption(IApplication applicationController)
        {
            Application = applicationController;
        }

        public abstract void Action();
    }
}
