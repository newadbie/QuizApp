﻿using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public partial class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; protected set; }

        public bool IsCorrect = false;

        protected Answer(string title)
        {
            Title = title;
        }
    }
}
