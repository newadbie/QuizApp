using System.Collections.Generic;

namespace QuizApp.Models
{
    public partial class Question
    {
        public string Title { get; protected set; }
        private List<Answer> _answers = new List<Answer>();

        protected Question(string title)
        {
            Title = title;
        }
    }
}
