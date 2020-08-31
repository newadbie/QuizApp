using QuizApp.Interfaces;

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
