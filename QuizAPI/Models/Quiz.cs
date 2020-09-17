using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
