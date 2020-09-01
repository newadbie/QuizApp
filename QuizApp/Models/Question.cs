using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp.Models
{
    public partial class Question
    {
        private readonly List<Answer> _answers = new List<Answer>();
        public string Title { get; protected set; }

        protected Question(string title)
        {
            Title = title;
        }

        public void AddAnswer(Answer answerToAdd)
        {
            _answers.Add(answerToAdd);
        }

        public List<Answer> GetAnswers()
        {
            if (_answers.Count == 0)
            {
                throw new Exception("Not created any answer yet");
            }

            return _answers;
        }
    }
}

