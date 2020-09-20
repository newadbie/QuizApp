using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAPI.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
    }
}
