using System;
using QuizApp.Controllers;
using QuizApp.Models;

namespace QuizApp.Views
{
    public class QuizView
    {
        private readonly QuizController _quizController = new QuizController();
        private readonly GameConfiguration _gameConfiguration;

        public QuizView()
        {
            _gameConfiguration = new GameConfiguration(4,4);
        }
        public void Greetings()
        {
            Console.WriteLine("Hello in my quiz application!");
        }

        public void Menu()
        {
            Console.WriteLine("1. Create new quiz!");
            Console.WriteLine("2. Exit game!");
            EMenuOptions selectedOption = _quizController.SelectOption();

            switch (selectedOption)
            {
                case EMenuOptions.ExitQuiz: _quizController.ExitApplication();
                    break;
                case EMenuOptions.NewQuiz: NewQuiz();
                    break;
            }
        }

        public void NewQuiz()
        {
            Console.WriteLine("Give me a name of your new Quiz!");
            Quiz newQuiz = _quizController.CreateNewQuiz(Console.ReadLine());
            CreateQuestion(newQuiz);
        }

        public void CreateQuestion(Quiz quizToAddQuestion)
        {
            Console.WriteLine("Give me a name of your new Question!");
            QuestionController questionController = new QuestionController(quizToAddQuestion, _gameConfiguration);
            Question newQuestion = questionController.CreateNewQuestion(Console.ReadLine());
            Console.WriteLine("ELO");
        }
    }
}
