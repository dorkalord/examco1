using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class CensorFullDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ExamID { get; set; }
    }

    public class CensorDto
    {
        public int UserID { get; set; }
        public int ExamID { get; set; }
    }
}
