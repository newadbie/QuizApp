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
        private readonly uint _numberOfAnswers;
        private List<Answer> _answers = new List<Answer>();

        protected Question(string title, uint numberOfAnswers)
        {
            Title = title;
            _numberOfAnswers = numberOfAnswers;
        }

        public List<Answer> GetAnswers()
        {
            if (_answers.Count != _numberOfAnswers)
            {
                throw new Exception("Incorrect number of answers!");
            }
            return _answers;
        }

        public void AddAnswer(Answer answer)
        {
            _answers.Add(answer);
        }

        public void SetAnswers(List<Answer> answers)
        {
            if (answers.Count != _numberOfAnswers)
            {
                throw new Exception("Not enough answers!");
            }

            if (answers.Select(x => x).Count(x => x.IsCorrect) != 1)
            {
                throw new Exception("Must be only one correct answer!");
            }

            _answers = answers;
        }
    }
}
