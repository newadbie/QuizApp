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

        public override void ShowPage()
        {
            int pagesToSkip = (CurrentPage - 1) * 7;
            var quizzesToShow = ItemsInList.Select(x => x)
                .Skip(pagesToSkip)
                .Take(PagesOnPage);

            int i = 1;
            foreach (var item in quizzesToShow)
            {
                Console.WriteLine($"[{i++}]. {item.Title}");
            }
        }
    }
}
