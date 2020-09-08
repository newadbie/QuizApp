using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Validators;

namespace QuizApp.Interfaces
{
    public abstract class Page<T> : IPage<T>
    {
        public int Pages { get; }
        public int CurrentPage { get; private set; } = 1;
        public abstract int ItemsOnPage { get; }
        public List<T> ItemsInList { get; }

        protected Page(List<T> itemsToList)
        {
            ItemsInList = itemsToList;
            Pages = (int)Math.Ceiling((double) ItemsInList.Count / 7);
        }

        public List<T> ItemsAtPage()
        {
            int pagesToSkip = (CurrentPage - 1) * ItemsOnPage;

            return ItemsInList.Select(x => x)
                .Skip(pagesToSkip)
                .Take(ItemsOnPage).ToList();
        }

        public void PreviousPage()
        {
            if (!IsFirstPage())
            {
                CurrentPage--;
            }
        }

        public void NextPage()
        {
            if (!IsLastPage())
            {
                CurrentPage++;
            }
        }

        public T SelectItem()
        {
            int firstFreeIndex;
            int nextPageIndex;
            int previousPageIndex;

            while (true)
            {
                firstFreeIndex = ItemsAtPage().Count;
                nextPageIndex = IsLastPage() ? -1 : firstFreeIndex++;
                previousPageIndex = IsFirstPage() ? -1 : firstFreeIndex++; 
                Console.Clear();
                MenuPage();
                if (ConsoleEx.TryReadInt(out int input))
                {
                    if (input >= 1 && input < ItemsInCurrentPage())
                    {
                        int itemIndex = input + ((CurrentPage - 1) * ItemsOnPage) - 1;
                        return ItemsInList[itemIndex];
                    }

                    if (input - 1 == nextPageIndex && !IsLastPage())
                    {
                        NextPage();
                        continue;;
                    }
                    if (input - 1 == previousPageIndex && !IsFirstPage())
                    {
                        PreviousPage();
                        continue;
                    }
                }
                Console.Clear();
                Console.WriteLine("Incorrect input!");
                Console.ReadLine();
            }
        }

        public int ItemsInCurrentPage()
        {
            return (ItemsInList.Count % 7) + 1 ;
        }

        public bool IsLastPage() => CurrentPage == Pages;
        public bool IsFirstPage() => CurrentPage == 1;

        public abstract void MenuPage();
    }
}
