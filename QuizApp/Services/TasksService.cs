using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Interfaces;

namespace QuizApp.Services
{
    public class TasksService : ITasksService
    {
        public List<Task> Tasks { get; private set; } = new List<Task>();

        public void AddTask(Task taskToAdd)
        {
            Tasks.Add(taskToAdd);
        }
    }
}
