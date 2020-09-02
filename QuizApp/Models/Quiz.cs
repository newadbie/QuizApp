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

        protected Quiz(string title)
        {
            Title = title;
        }

        public void AddQuestion(Question questionToAdd)
        {
            Questions.Add(questionToAdd);
        }

        public List<Question> Questions { get; } = new List<Question>();
    }
}
