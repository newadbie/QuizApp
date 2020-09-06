using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Models
{
    public partial class Question
    {
        public static Question Create(string title)
        {
            if (!title.IsTitleCorrect())
            {
                throw new Exception("Title is incorrect");
            }
            
            return new Question(title);
        }

        public static Quiz CreateQuestions(Quiz newQuiz, MenuView menuView, GameConfiguration gameConfiguration)
        {
            int maxNumberOfQuestions = gameConfiguration.MaxQuestions;
            menuView.HowManyQuestions();

            if (!Console.ReadLine()
                .ParseInRange(0, maxNumberOfQuestions, out int input))
            {
                Console.WriteLine("Incorrect input!");
                return null;
            }
            Console.Clear();
            for (int i = 0; i < input; i++)
            {
                menuView.AskForQuestion(i + 1);
                string questionTitle = Console.ReadLine();
                Question question = Create(questionTitle);
                Console.Clear();
                CreateAnswers(question, gameConfiguration.NumberOfAnswers, menuView);
                SelectCorrectAnswer(question, menuView);

                newQuiz.AddQuestion(question);
                Console.Clear();
            }

            return newQuiz;
        }

        private static void CreateAnswers(Question currentQuestion, int numberOfAnswers, MenuView menuView)
        {
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.Clear();
                menuView.AskForAnswer(i + 1);
                Answer newAnswer = Answer.Create(Console.ReadLine());
                currentQuestion.AddAnswer(newAnswer);
            }
        }

        private static void SelectCorrectAnswer(Question currentQuestion, MenuView menuView)
        {
            Console.Clear();
            List<Answer> answers = currentQuestion.Answers;
            List<string> answersTitle = answers.Select(x => x.Title).ToList();
            menuView.ShowAnswers(answersTitle);

            if (Console.ReadLine().SelectIntParse(answersTitle.Count, out int input))
            {
                answers[input - 1].IsCorrect = true;
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
