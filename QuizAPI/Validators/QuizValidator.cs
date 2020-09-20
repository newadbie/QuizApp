using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public class QuizValidator : IValidator<Quiz>
    {
        public IEnumerable<string> ValidationErrors { get; }
        public bool Validate(Quiz value)
        {
            throw new NotImplementedException();
        }
    }
}
