using System.Collections.Generic;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Views
{
    public class ReplyForView : Page<Quiz>
    {
        public ReplyForView(List<Quiz> itemsToList) : base(itemsToList)
        {
        }

        public override void ShowPage()
        {
        }

    }
}
