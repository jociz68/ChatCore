using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Model
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public string Session { get; set; }
        //public int? AnswerID { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
