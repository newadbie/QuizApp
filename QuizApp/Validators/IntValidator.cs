using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using QuizApp.Exceptions;

namespace QuizApp.Validators
{
    public static class IntValidator
    {
        public static int SelectIntParse(this string a, int arrayLength)
        {
            bool isIntInputCorrect = int.TryParse(a, out int result)
                                     && result - 1 >= 0
                                     && result - 1 < arrayLength;
            if (!isIntInputCorrect)
            {
                return -1;
            }

            return result;
        }

        public static int ParseInRange(this string a, int minRange, int maxRange)
        {
            bool isIntInputCorrect = int.TryParse(a, out int result)
                                     && result >= minRange
                                     && result <= maxRange;
            if (!isIntInputCorrect)
            {
                throw new IncorrectInputException();
            }

            return result;
        }
    }
}
