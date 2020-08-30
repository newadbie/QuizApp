using System.ComponentModel.DataAnnotations;
using QuizApp.Exceptions;
using QuizApp.Validators;

namespace QuizApp.Models
{
    public partial class Answer
    {
        private string _title;

        public bool IsCorrect = false;

        protected Answer(string title)
        {
            _title = title;
        }
    }
}
