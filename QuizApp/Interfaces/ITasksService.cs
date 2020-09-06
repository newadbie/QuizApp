using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Interfaces
{
    public interface ITasksService
    {
        List<Task> Tasks { get; }
        void AddTask(Task taskToAdd);
    }
}
