using System.ComponentModel.DataAnnotations;
using QuizApp.Exceptions;

namespace QuizApp.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }

        private string _title;

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

        public bool IsCorrect = false;

        public Answer(string title)
        {
            Title = title;
        }
    }
}
