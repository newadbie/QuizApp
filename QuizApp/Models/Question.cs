using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuizApp.Controllers;
using QuizApp.Exceptions;

namespace QuizApp.Models
{
    public partial class Question
    {
        public string Title { get; protected set; }
        private List<Answer> _answers = new List<Answer>();

        protected Question(string title)
        {
            Title = title;
        }
    }
}
