using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Interfaces;

namespace QuizApp.Models
{
    public class QuizPage : Page<Quiz>
    {
        public QuizPage(List<Quiz> itemsToList) : base(itemsToList)
        {
        }

        public override int ItemsOnPage { get; } = 7;

        public override void MenuPage()
        {
            int i = 1;
            foreach (var item in ItemsAtPage())
            {
                Console.WriteLine($"[{i++}]. {item.Title}");
            }

            Console.WriteLine();
            Console.WriteLine();

            if (!IsLastPage())
            {
                Console.WriteLine($"[{i++}]. Next page!");
            }

            if (!IsFirstPage())
            {
                Console.WriteLine($"[{i++}]. Previous page!");
            }
        }
    }
}
