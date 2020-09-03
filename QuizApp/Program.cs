using System.Reflection;
using Autofac;
using QuizApp.Models.Menu;

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
            using (var scope = Container.BeginLifetimeScope())
            {
                var menu = scope.Resolve<Menu>();
                menu.ShowMenu();
                var menuAction = menu.SelectMenuOption();

                menuAction.Action();
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
