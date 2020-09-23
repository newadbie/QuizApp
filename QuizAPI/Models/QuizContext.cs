using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizAPI.Models
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Option>().HasData(
                new Option() { Id = 1, Name = "MinQuizTitleLength", IntValue = 1,},
                new Option() { Id = 2, Name = "MaxQuizTitleLength", IntValue = 40 },
                new Option() { Id = 3, Name = "MinQuestionTitleLength", IntValue = 1 },
                new Option() { Id = 4, Name = "MaxQuestionTitleLength", IntValue = 40 },
                new Option() { Id = 5, Name = "NumberOfAnswers", IntValue = 4 }
            );
        }
    }
}
