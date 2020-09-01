using System;
using System.Linq;
using QuizApp.Exceptions;
using QuizApp.Interfaces;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Models.Menu.Options
{
    public class MenuOptionNewQuiz : MenuOption
    {
        private readonly MenuView _menuView;
        private Quiz _newQuiz;

        public MenuOptionNewQuiz(MenuView menuView,
            IApplication applicationController) : base(applicationController)
        {
            _menuView = menuView;
        }

        public override void Action()
        {
            _menuView.GiveQuizName();
            string quizName = Console.ReadLine();
            _newQuiz = Quiz.Create(quizName);
            Console.Clear();

            CreateQuestions();
        }

        private void CreateQuestions()
        {
            _menuView.HowManyQuestions();
            try
            {
                int maxNumberOfQuestions = Application.GetMaxNumberOfQuestions();

                int input = Console.ReadLine().ParseInRange(0, maxNumberOfQuestions);
                Console.Clear();
                for (int i = 0; i < input; i++)
                {
                    _menuView.AskForQuestion(i + 1);
                    string questionTitle = Console.ReadLine();
                    var question = Question.Create(questionTitle);
                    Console.Clear();
                    CreateAnswers(question);
                    SelectCorrectAnswer(question);

                    _newQuiz.AddQuestion(question);
                    Console.Clear();
                }
            }
            catch (IncorrectInputException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void CreateAnswers(Question currentQuestion)
        {
            int numberOfAnswers = Application.GetNumberOfAnswers();
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.Clear();
               _menuView.AskForAnswer(i + 1);
               var newAnswer = Answer.Create(Console.ReadLine());
               currentQuestion.AddAnswer(newAnswer);
            }
        }

        private void SelectCorrectAnswer(Question currentQuestion)
        {
            Console.Clear();
            var answers = currentQuestion.GetAnswers();
            var answersTitle = answers.Select(x => x.Title).ToList();
            _menuView.ShowAnswers(answersTitle);

            var correctAnswer = Console.ReadLine().SelectIntParse(answersTitle.Count);
            if (correctAnswer != -1)
            {
                answers[correctAnswer - 1].IsCorrect = true;
            }
            else
            {
                throw new Exception("Incorrect");
            }
        }
    }
}
