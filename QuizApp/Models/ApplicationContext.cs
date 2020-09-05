using Microsoft.EntityFrameworkCore;

namespace QuizApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ApplicationDB;Trusted_Connection=True;");
        }
    }
}
