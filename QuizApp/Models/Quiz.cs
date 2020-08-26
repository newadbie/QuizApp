using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuizApp.Exceptions;

namespace QuizApp.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        private string _title;
        private readonly List<Question> _questions = new List<Question>();

        public Quiz(string title)
        {
            Title = title;
        }

        public List<Question> GetQuestions()
        {
            if (_questions.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _questions;
        }

        public void AddQuestion(Question questionToAdd)
        {
            _questions.Add(questionToAdd);
        }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new IncorrectInputException();
                }

                _title = value;
            }
        }
    }
}
