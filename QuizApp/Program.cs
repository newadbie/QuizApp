using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using QuizApp.Controllers;
using QuizApp.Interfaces;
using QuizApp.Models;
using QuizApp.Models.Builders;
using QuizApp.Models.Menu;
using QuizApp.Models.Menu.Interfaces;
using QuizApp.Services;
using QuizApp.Validators;
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

            var menu = scope.Resolve<Menu>();
            var menuView = new MenuView();

            while (!menu.Exit)
            {
                menuView.ShowMenu(menu);

                if (!ConsoleEx.TryReadInt(out int input))
                {
                    Console.WriteLine("Incorrect input!");
                }
                else
                {
                    IMenuOption menuAction = menu.SelectMenuOption(input);
                    if (menuAction == null)
                    {
                        Console.WriteLine("Incorrect input!");
                    }
                    else
                    {
                        Console.Clear();
                        menuAction?.Action();
                    }
                }
            }

            ITasksService tasksService = scope.Resolve<ITasksService>();
            Console.WriteLine("Wait... I am just ending actions!");
            Task.WaitAll(tasksService.Tasks.ToArray());
        }

        private static void Build()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<GameConfiguration>().InstancePerDependency();
            builder.RegisterType<DatabaseController>().As<IDatabase>().InstancePerDependency();
            builder.RegisterType<Menu>().InstancePerDependency();
            builder.RegisterType<MenuView>().InstancePerDependency();
            builder.RegisterType<QuestionBuilder>().InstancePerDependency();
            builder.RegisterType<TasksService>().As<ITasksService>().SingleInstance();

            Container = builder.Build();
        }
    }
}
