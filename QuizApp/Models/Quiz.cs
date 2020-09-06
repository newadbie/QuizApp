using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuizApp.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; protected set; }

        public Quiz(string title)
        {
            Title = title;
        }

        public void AddQuestion(Question questionToAdd)
        {
            Questions.Add(questionToAdd);
        }

        public bool HasQuestions() => Questions.Count != 0;

        public List<Question> Questions { get; } = new List<Question>();
    }
}
