using System;
using System.Collections.Generic;
using QuizAPI.Validators;

namespace QuizAPI.Models
{
    public abstract class ValidatorWithOptions<T> : IValidator<T>
    {
        protected readonly List<Option> Options;
        public abstract List<string> ValidationErrors { get; protected set; }
        public abstract bool Validate(T value);

        protected ValidatorWithOptions(List<Option> options)
        {
            if (options == null || options.Count == 0)
            {
                throw new Exception("You forget about options!");
            }

            Options = options;
        }
    }
}
