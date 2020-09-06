using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Validators;
using QuizApp.Views;
using System.Reflection.Metadata.Ecma335;

namespace QuizApp.Models.Builders
{
    public class QuestionBuilder
    {
        private readonly MenuView _menuView;
        private readonly GameConfiguration _gameConfiguration;
        private readonly TitleValidator _titleValidator;

        public QuestionBuilder(MenuView menuView, GameConfiguration gameConfiguration)
        {
            _menuView = menuView;
            _gameConfiguration = gameConfiguration;
            _titleValidator = new TitleValidator();
        }

        public Quiz CreateQuestions(Quiz newQuiz)
        {
            Console.WriteLine("How many questions do you have?");

            int maxNumberOfQuestions = _gameConfiguration.MaxQuestions;
            var rangeValidator = new RangeValidator(1, maxNumberOfQuestions);

            int input;
            while (true)
            {
                if (!ConsoleEx.TryReadInt(out input)) continue;

                if (rangeValidator.Validate(input))
                {
                    break;
                }

                foreach (var validationError in rangeValidator.ValidationErrors)
                {
                    Console.WriteLine(validationError);
                }
            }

            Console.Clear();
            for (int i = 0; i < input; i++)
            {
                Console.WriteLine($"Please give me a title to  question {i + 1}");

                while (true)
                {
                    string questionTitle = Console.ReadLine();
                    if (_titleValidator.Validate(questionTitle))
                    {
                        Question question = new Question(questionTitle);
                        Console.Clear();
                        CreateAnswers(question);
                        SelectCorrectAnswer(question);
                        newQuiz.AddQuestion(question);
                        Console.Clear();
                        break;
                    }
                    foreach (var validationError in _titleValidator.ValidationErrors)
                    {
                        Console.WriteLine(validationError);
                    }
                }
            }

            return newQuiz;
        }

        private void CreateAnswers(Question currentQuestion)
        {
            int numberOfAnswers = _gameConfiguration.NumberOfAnswers;
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.Clear();
                Console.WriteLine($"Give the text for answer {i + 1}");
                while (true)
                {
                    string value = Console.ReadLine();  
                    if (_titleValidator.Validate(value))
                    {
                        Answer newAnswer = new Answer(value); 
                        currentQuestion.AddAnswer(newAnswer);
                        break;
                    }

                    Console.Clear();
                    foreach (var validateError in _titleValidator.ValidationErrors)
                    {
                        Console.WriteLine(validateError);
                    }

                    Console.WriteLine($"Incorrect input, give the text for answer { i + 1 }");
                }

            }
        }

        private void SelectCorrectAnswer(Question currentQuestion)
        {
            Console.Clear();
            List<Answer> answers = currentQuestion.Answers;
            List<string> answersTitle = answers.Select(x => x.Title).ToList();

            while (true)
            {
                _menuView.ShowAnswers(answersTitle);

                if (ConsoleEx.TryReadInt(out int input))
                {
                    if (input > 0 && input < answersTitle.Count)
                    {
                        answers[input - 1].IsCorrect = true;
                        break;
                    }
                }

                Console.WriteLine("Incorrect input!");
            }
        }
    }
}
