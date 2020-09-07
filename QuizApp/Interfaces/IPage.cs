using System.Collections.Generic;

namespace QuizApp.Interfaces
{
    public interface IPage<T>
    {
        int Pages { get; }
        int CurrentPage { get; }
        int ItemsOnPage { get; }

        List<T> ItemsInList { get; }
        List<T> ItemsAtPage();

        void PreviousPage();
        void NextPage();
        void MenuPage();
        T SelectItem();
        int ItemsInCurrentPage();
        bool IsLastPage();
        bool IsFirstPage();
    }
}
