﻿using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; protected set; }

        public bool IsCorrect { get; set; } = false;

        public Answer(string title)
        {
            Title = title;
        }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
