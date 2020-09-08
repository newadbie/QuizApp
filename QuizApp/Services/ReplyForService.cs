using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Interfaces;
using QuizApp.Models;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp.Services
{
    public class ReplyForService
    {
        private readonly IDatabase _db;
        private readonly ITasksService _tasksService;
        private List<Answer> _selectedAnswers;
        private Quiz selectedQuiz;
        private List<Quiz> _quizzes;

        public ReplyForService(IDatabase db,
            ITasksService tasksService
            )
        {
            _db = db;
            _tasksService = tasksService;
        }

        public async Task LoadQuizzes()
        {
            _quizzes = await _db.GetQuizzes();
        }

        public async void SelectQuiz()
        {
            if (_quizzes == null)
            {
                await LoadQuizzes();
            }

            Task.WaitAll(_tasksService.Tasks.ToArray());

            QuizPage quizPage = new QuizPage(_quizzes);
            selectedQuiz = quizPage.SelectItem();

            _selectedAnswers = new List<Answer>();
            AnswerForQuestions();
            Console.Clear();
            ShowSelectedAnswers();
        }

        private void AnswerForQuestions()
        {
            foreach (var question in selectedQuiz.Questions)
            {
                Console.Clear();
                Console.WriteLine($"{question.Title}");
                Console.WriteLine();

                int answerNumber = 1;
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine($"[{ answerNumber++ }]. {answer.Title}");
                }

                var rangeValidator = new RangeValidator(1, answerNumber);

                while (true)
                {
                    if (ConsoleEx.TryReadInt(out int input))
                    {
                        if (rangeValidator.Validate(input))
                        {
                            _selectedAnswers.Add(question.Answers[input - 1]);
                            break;
                        }

                        Console.WriteLine("Number is out of range!");
                    }

                    Console.WriteLine("Incorrect input!");
                }
            }
        }

        private void ShowSelectedAnswers()
        {
            if (_selectedAnswers.Count != 0)
            {
                int questionIndex = 0;
                foreach (var question in selectedQuiz.Questions)
                {
                    Console.WriteLine(question.Title);
                    Console.WriteLine();
                    int answerNumber = 1;
                    foreach (var answer in question.Answers)
                    {
                        if (answer.IsCorrect && _selectedAnswers[questionIndex] == answer || answer.IsCorrect && _selectedAnswers[questionIndex] != answer)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (!answer.IsCorrect && _selectedAnswers[questionIndex] == answer)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        Console.WriteLine($"[{answerNumber++}]. {answer.Title}");
                        Console.ResetColor();
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
