using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizAPI.Models;

namespace QuizAPI.Validators
{
    public interface IValidator<T>
    {
        IEnumerable<string> ValidationErrors { get; }
        bool Validate(T value);
    }
}
