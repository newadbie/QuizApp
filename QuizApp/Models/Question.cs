using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public List<Answer> Answers { get; } = new List<Answer>();

        public string Title { get; protected set; }

        public Question(string title)
        {
            Title = title;
        }

        public void AddAnswer(Answer answerToAdd)
        {
            Answers.Add(answerToAdd);
        }

        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }
    }
}

