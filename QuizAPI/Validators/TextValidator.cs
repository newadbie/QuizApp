using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizAPI.Validators
{
    public class TextValidator : IValidator<string>
    {
        public List<string> ValidationErrors { get; private set; }
        private readonly int _minTextLength;
        private readonly int _maxTextLength;
        private readonly List<string> _forbiddenWords;

        protected TextValidator(int minTextLength, int maxTextLength, List<string> forbiddenWords = null)
        {
            _minTextLength = minTextLength;
            _maxTextLength = maxTextLength;
            _forbiddenWords = forbiddenWords;
        }

        public static TextValidator Create(int minTextLength, int maxTextLength, List<string> forbiddenWords = null)
        {

            if (minTextLength <= 0)
            {
                throw new Exception("Incorrect minimal text length");
            }

            if (minTextLength >= maxTextLength)
            {
                throw new Exception("Minimal text length cannot be greater or equal than maximal text length");
            }
            
            return new TextValidator(minTextLength, maxTextLength, forbiddenWords);
        }

        public bool Validate(string? value)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) )
            {
                errors.Add("Text cannot be empty");
                ValidationErrors = errors;
                return false;
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
