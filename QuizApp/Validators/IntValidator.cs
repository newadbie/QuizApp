using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Validators
{
    public static class IntValidator
    {
        public static int SelectIntParse(this string a, int arrayLength)
        {
            bool isIntInputCorrect = int.TryParse(a, out int result) 
                                     && result - 1 >= 0
                                     && result - 1 < arrayLength;
            return result;
        }
    }
}
