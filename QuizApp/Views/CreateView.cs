using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Views
{
    public class CreateView
    {
        public void GiveQuizName()
        {
            Console.WriteLine("Give me a quiz name!");
        }

        public void HowManyQuestions()
        {
            Console.WriteLine("How many questions do you want to have?");
        }

        public void AskForQuestion(int numberOfQuestion)
        {
            Console.WriteLine($"Please give ma a title to {numberOfQuestion} question");
        }
    }
}
