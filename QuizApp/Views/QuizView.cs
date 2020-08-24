using System;
using System.Collections.Generic;
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
            Console.Clear();
            
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
            Console.Clear();
            CreateQuestion(newQuiz);
        }

        public void CreateQuestion(Quiz quizToAddQuestion)
        {
            Console.WriteLine("Give me a name of your new Question!");
            QuestionController questionController = new QuestionController(quizToAddQuestion, _gameConfiguration);

            Question newQuestion = questionController.CreateNewQuestion(Console.ReadLine());
            Console.Clear();
            CreateAnswers(newQuestion, questionController);
        }

        public void CreateAnswers(Question questionToAddAnswer, QuestionController questionController)
        {
            List<Answer> tempAnswers = new List<Answer>();
            for (int i = 0; i < _gameConfiguration.numberOfAnswers; i++)
            {
                Console.WriteLine($"Answer number { i + 1 }");
                Console.WriteLine("Give answer option!");
                tempAnswers.Add(questionController.CreateAnswer());
                Console.Clear();
            }

            Console.WriteLine("Which answer is correct?");
            for (int i = 0; i < tempAnswers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tempAnswers[i].Title}");
            }

            tempAnswers = questionController.SelectCorrectAnswer(tempAnswers);
            questionToAddAnswer.SetAnswers(tempAnswers);
            Console.Clear();
        }
    }
}
