using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using QuizApp.Models.Menu;
using QuizApp.Services;

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
            using var scope = Container.BeginLifetimeScope();
            var menu = scope.Resolve<Menu>();
            for (;;)
            {
                menu.ShowMenu();
                var menuAction = menu.SelectMenuOption();
                Console.Clear();
                menuAction?.Action(); 
            }
        }

        private static void Build()
        {
            var builder = new ContainerBuilder();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
                .AsSelf()
                .AsImplementedInterfaces();

            Container = builder.Build();
        }
    }
}
