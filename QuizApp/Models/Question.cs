using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuizApp.Exceptions;

namespace QuizApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int QuizId { get; set; }

        private readonly uint _numberOfAnswers;
        private string _title;
        private List<Answer> _answers = new List<Answer>();

        public string Title
        {
            get => _title;
            private set
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
