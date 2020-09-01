using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public partial class Quiz
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; protected set; }
        private readonly List<Question> _questions = new List<Question>();
        protected Quiz(string title)
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
    }
}
