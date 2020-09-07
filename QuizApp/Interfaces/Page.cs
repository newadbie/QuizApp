using System;
using System.Collections.Generic;

namespace QuizApp.Interfaces
{
    public abstract class Page<T> : IPage<T>
    {
        public int Pages { get; }
        public int CurrentPage { get; private set; } = 1;
        public virtual int PagesOnPage { get; } = 7;
        public List<T> ItemsInList { get; }

        protected Page(List<T> itemsToList)
        {
            ItemsInList = itemsToList;
            Pages = (int)Math.Ceiling((double) ItemsInList.Count / 7);
        }

        public void LastPage()
        {
            if (CurrentPage - 1 > 0)
            {
                CurrentPage--;
            }
        }

        public void NextPage()
        {
            if (CurrentPage + 1 < Pages)
            {
                CurrentPage++;
            }
        }

        public int ItemsInCurrentPage()
        {
            if (CurrentPage != Pages)
            {
                return 7;
            }
         
            return ItemsInList.Count % 7;
        }

        public bool IsLastPage() => CurrentPage == Pages;
        public bool IsFirstPage() => CurrentPage == 1;

        public abstract void ShowPage();
    }
}
