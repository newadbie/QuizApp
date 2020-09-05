using QuizApp.Exceptions;

namespace QuizApp.Validators
{
    public static class IntValidator
    {
        public static bool SelectIntParse(this string a, int arrayLength, out int intInput)
        {
            bool isIntInputCorrect = int.TryParse(a, out intInput)
                                     && intInput - 1 >= 0
                                     && intInput - 1 < arrayLength;

            return isIntInputCorrect;
        }

        public static bool ParseInRange(this string a, int minRange, int maxRange, out int intInput)
        {
            bool isIntInputCorrect = int.TryParse(a, out intInput)
                                     && intInput >= minRange
                                     && intInput <= maxRange;
            return isIntInputCorrect;
        }
    }
}
