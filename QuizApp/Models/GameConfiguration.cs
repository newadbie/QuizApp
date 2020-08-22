using System;

namespace QuizApp.Models
{
    public class GameConfiguration
    {
        public int MaxQuestions { get; }
        public int numberOfAnswers { get; }

        public GameConfiguration(int maxQuestions, int maxAnswers)
        {
            MaxQuestions = maxQuestions;
            numberOfAnswers = maxAnswers;
        }
    }
}
