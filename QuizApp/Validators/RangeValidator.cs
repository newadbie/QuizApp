using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Validators
{
    public class RangeValidator : IValidator<int>
    {
        private readonly int _minRange;
        private readonly int _maxRange;

        public IEnumerable<string> ValidationErrors { get; private set; }

        public RangeValidator(int minRange, int maxRange)
        {
            _minRange = minRange;
            _maxRange = maxRange;
        }

        public bool Validate(int value)
        {
            List<string> validationErrors = new List<string>();

            if (value < _minRange)
            {
                validationErrors.Add($"Value cannot be less than {_minRange}");
            }
            else if (value > _maxRange)
            {
                validationErrors.Add($"Value cannot be greater than {_maxRange}");
            }

            ValidationErrors = validationErrors;
            return value >= _minRange && value <= _maxRange;
        }
    }
}
