using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizAPI.Validators
{
    public class TextValidator : IValidator<string>
    {
        public IEnumerable<string> ValidationErrors { get; private set; }
        private readonly int _minTextLength;
        private readonly int _maxTextLength;
        private readonly List<string> _forbiddenWords;

        public TextValidator(int minTextLength, int maxTextLength, List<string> forbiddenWords = null)
        {
            _minTextLength = minTextLength;
            _maxTextLength = maxTextLength;
            _forbiddenWords = forbiddenWords;
        }

        public bool Validate(string value)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(value))
            {
                errors.Add("Value cannot be empty");
            }

            if (value.Length < _minTextLength)
            {
                errors.Add("Text is too short");
            }

            if (value.Length > _maxTextLength)
            {
                errors.Add("Text is too long");
            }

            if (_forbiddenWords != null)
            {
                foreach (var forbiddenWord in _forbiddenWords)
                {
                    var regex = new Regex(@"\b"+forbiddenWord, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                    if (regex.IsMatch(value))
                    {
                        errors.Add("Text include forbidden word!");
                    }
                }
            }

            ValidationErrors = errors;
            if (errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
