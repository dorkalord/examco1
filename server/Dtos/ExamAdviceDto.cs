using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ExamAdviceDto
    {
        public int ID { get; set; }
        public int ExamAttemptID { get; set; }
        public int AdviceID { get; set; }
        public int ExamCritereaID { get; set; }

        public float Total { get; set; }
        public virtual ExamCritereaDto ExamCriterea { get; set; }
        public virtual AdviceDto Advice { get; set; }
    }
}
