using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class TasksService
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void AddTask(Task taskToAdd)
        {
            var newTask = Task.Factory.StartNew(() => taskToAdd);
            _tasks.Add(newTask);
            newTask.Wait();
            _tasks.Remove(newTask);
        }

        public void RemoveTask(Task taskToRemove)
        {
            _tasks.Remove(taskToRemove);
        }

        public List<Task> GetTasks() => _tasks;
    }
}
