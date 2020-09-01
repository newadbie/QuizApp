namespace QuizApp.Models
{
    public partial class Answer
    {
        public string Title { get; protected set; }

        public bool IsCorrect = false;

        protected Answer(string title)
        {
            Title = title;
        }
    }
}
