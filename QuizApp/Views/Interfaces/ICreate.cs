namespace QuizApp.Views.Interfaces
{
    public interface ICreate
    {
        void GiveQuizName();
        void HowManyQuestions();
        void AskForQuestion(int numberOfQuestion);
    }
}
