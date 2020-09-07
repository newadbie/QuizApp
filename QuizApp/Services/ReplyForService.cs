using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Interfaces;
using QuizApp.Models;
using QuizApp.Views;

namespace QuizApp.Services
{
    public class ReplyForService
    {
        private readonly IDatabase _db;
        private readonly ITasksService _tasksService;
        private readonly MenuView _menuView;
        private List<Quiz> _quizzes;

        public ReplyForService(IDatabase db,
            ITasksService tasksService,
            MenuView menuView)
        {
            _db = db;
            _tasksService = tasksService;
            _menuView = menuView;
        }

        public async void LoadQuizzes()
        {
            _quizzes = await _db.GetQuizzes();
        }

        public void SelectQuiz()
        {
            while (true)
            {
                if (_quizzes != null)
                {
                    QuizPage quizPage = new QuizPage(_quizzes);
                    _menuView.ShowQuizzes(_quizzes.Select(x => x.Title).ToList());
                    break;
                }
                Console.Clear();
                Console.WriteLine("Loading data...");
                LoadQuizzes();
            }

            Console.ReadLine();
        }
    }
}
