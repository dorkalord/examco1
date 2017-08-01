using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ArgumentCritereaDto
    {
        public float Severity { get; set; }
        public int ExamCritereaID { get; set; }
        public int ArgumentID { get; set; }
    }

    public class ArgumentCritereaFullDto
    {
        public int ID { get; set; }
        public float Severity { get; set; }
        public int ExamCritereaID { get; set; }
        public int ArgumentID { get; set; }
    }
}
