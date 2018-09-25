using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Model
{
    public class Answer
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime AnswerTime { get; set; }
        public int QuestionID { get; set; }
        public int UserId { get; set; }
    }
}
