using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class GradeDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public float Min { get; set; }
        public float Max { get; set; }
        public float Top { get; set; }

        public int ExamID { get; set; }
    }
}
