using System;
using QuizApp.Models;
using QuizApp.Exceptions;

namespace QuizApp.Services
{
    public class MenuService
    {
        public void MenuSelect()
        {
            if (!int.TryParse(Console.ReadLine(), out var opt) 
            || Enum.GetName(typeof(EMenuOptions), opt) == null)
            {
                throw new IncorrectInputException();
            }

            EMenuOptions selectedOption = Enum.Parse<EMenuOptions>(Enum.GetName(typeof(EMenuOptions), opt)!);
            switch (selectedOption)
            {
                case EMenuOptions.ExitQuiz: ExitApplication();
                    break;
                case EMenuOptions.NewQuiz: CreateNewQuiz();
                    break;
            }

        }

        private void CreateNewQuiz()
        {

        }

        private void ExitApplication()
        {
           Environment.Exit(1);
        }
    }
}
