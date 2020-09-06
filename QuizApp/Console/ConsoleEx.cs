using System;

namespace QuizApp.Validators
{
    public static class ConsoleEx
    {
        public static bool TryReadInt(out int value)
        {
            return int.TryParse(Console.ReadLine(), out value);
        }
    }
}
