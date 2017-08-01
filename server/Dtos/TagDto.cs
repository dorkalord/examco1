using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class TagDto
    {
        public int QuestionID { get; set; }
        public int TopicID { get; set; }
    }

    public class TagFullDto
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int TopicID { get; set; }
    }
}
