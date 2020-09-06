using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using QuizApp.Controllers;
using QuizApp.Interfaces;
using QuizApp.Models.Menu;
using QuizApp.Models.Menu.Interfaces;
using QuizApp.Views;

namespace QuizApp
{
    public class Program
    {
        private static IContainer Container { get; set; }
        
        private static void Main(string[] args)
        {
            Build();
            StartApplication();
        }

        private static void StartApplication()
        {
            using ILifetimeScope scope = Container.BeginLifetimeScope();
            Menu menu = scope.Resolve<Menu>();
            MenuView menuView = new MenuView();
            ITasksService  tasksService = SingletonTasksService.GetTasksService();

            while (!menu.Exit)
            {
                menuView.ShowMenu(menu);
                IMenuOption menuAction = menu.SelectMenuOption();
                Console.Clear();
                menuAction?.Action(); 
            }

            Console.WriteLine("Wait... I am just ending actions!");
            Task.WaitAll(tasksService.Tasks.ToArray());
        }

        private static void Build()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .Except<SingletonTasksService>(ct => ct.As<ITasksService>().SingleInstance())
                .AsSelf()
                .AsImplementedInterfaces();

            Container = builder.Build();
        }
    }
}
