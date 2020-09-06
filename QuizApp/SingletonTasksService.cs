using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.Interfaces;

namespace QuizApp
{
    public class SingletonTasksService : ITasksService
    {
        private static SingletonTasksService _instance;
        public List<Task> Tasks { get; } = new List<Task>(); 

        protected SingletonTasksService() { }

        public static SingletonTasksService GetTasksService() => _instance ??= new SingletonTasksService();

        public void AddTask(Task taskToAdd)
        {
            Tasks.Add(taskToAdd);
        }
    }
}
