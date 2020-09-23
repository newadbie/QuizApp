using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class CorrectAnswer
    {
        public int Id { get; set; }
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
    }
}
