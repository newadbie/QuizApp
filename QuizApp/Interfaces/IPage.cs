using System.Collections.Generic;

namespace QuizApp.Interfaces
{
    public interface IPage<T>
    {
        int Pages { get; }
        int CurrentPage { get; }
        int PagesOnPage { get; }
        List<T> ItemsInList { get; }

        void LastPage();
        void NextPage();
        void ShowPage();
        int ItemsInCurrentPage();
        bool IsLastPage();
        bool IsFirstPage();
    }
}
