using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class PostQuiz
    {
        public Quiz Quiz { get; set; }
        public Dictionary<int, int> CorrectAnswersInQuestion { get; set; }

        public bool IsValid() => Quiz != null && CorrectAnswersInQuestion != null;
    }
}
