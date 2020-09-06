using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Models;
using QuizApp.Models.Menu;
using QuizApp.Models.Menu.Interfaces;

namespace QuizApp.Views
{
    public class MenuView
    {
        public void ShowMenu(Menu menu)
        {
            foreach (string header in menu.Headers)
            {
                Console.WriteLine($"{header}");
            }
             
            int i = 1;
            foreach (IMenuOption option in menu.Options)
            {
                Console.WriteLine($"{i++}. {option.Text}");
            }

            Console.WriteLine("Make your choice!");
        }

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

        public void AskForAnswer(int answerNumber)
        {
             Console.WriteLine($"Give a {answerNumber} answer title");
        }

        public void ShowAnswers(List<string> answersTitle)
        {
            Console.WriteLine("Which answer is correct?");
            for (int i = 0; i < answersTitle.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answersTitle[i]}");
            }

        }
    }
}
