﻿using System.Collections.Generic;

namespace QuizAPI.Models
{
    public class Question
    {
        public int Id { get; set; }

        public List<Answer> Answers { get; set; }

        public string Title { get; set; }
        
        public Quiz Quiz { get; set; }
        public int QuizId { get; set; }
    }
}
