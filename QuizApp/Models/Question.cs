using System;
using System.Collections.Generic;
using QuizApp.Exceptions;

namespace QuizApp.Models
{
    public class Question
    {
        private readonly uint _numberOfAnswers;
        private readonly List<Answer> _answers = new List<Answer>();
        private string _title;

        public Question(uint numberOfAnswers)
        {
            _numberOfAnswers = numberOfAnswers;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new IncorrectInputException();
                }

                _title = value;
            }
        }

        public List<Answer> GetAnswers()
        {
            if (_answers.Count != _numberOfAnswers)
            {
                throw new Exception("Incorrect number of answers!");
            }
            return _answers;
        }
    }
}
