using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Validators
{
    public interface IValidator<T>
    {
        IEnumerable<string> ValidationErrors { get; }
        bool Validate(T value);
    }
}
