using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Tag
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int TopicID { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
