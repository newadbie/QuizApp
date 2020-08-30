using System;
using System.Reflection;
using Autofac;
using QuizApp.Controllers;
using QuizApp.Models.Menu;
using QuizApp.Validators;
using QuizApp.Views;

namespace QuizApp
{
    public class Program
    {
        private static IContainer Container { get; set; }

        private static void Build()
        {
            var builder = new ContainerBuilder();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsSelf()
                .AsImplementedInterfaces();

            Container = builder.Build();
        }


        private static void Main(string[] args)
        {
            Build();
            ShowMenu();
        }

        public static void ShowMenu()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var controller = scope.Resolve<MenuController>();
                for (;;)
                {
                    IMenuOption action = controller.MenuAction();
                    action.Action();
                }
            }
        }
    }
}
