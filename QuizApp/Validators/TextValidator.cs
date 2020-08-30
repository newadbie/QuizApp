using System;

namespace QuizApp.Validators
{
    public static class TextValidator
    {
        public static bool IsTitleCorrect(this string title)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("SDAD");
                return false;
            }

            return true;
        }
    }
}
