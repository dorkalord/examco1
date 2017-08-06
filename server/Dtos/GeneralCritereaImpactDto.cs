using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class GeneralCritereaImpactDto
    {
        public int ID { get; set; }
        public int ExamAttemptID { get; set; }
        public Nullable<int> AnwserID { get; set; }
        public Nullable<int> MistakeID { get; set; }
        public int ExamCritereaID { get; set; }
        public float Weight { get; set; }
    }

    public class GeneralCritereaImpactCreateDto
    {
        public int ExamAttemptID { get; set; }
        public Nullable<int> AnwserID { get; set; }
        public Nullable<int> MistakeID { get; set; }
        public int ExamCritereaID { get; set; }
        public float Weight { get; set; }
    }
}
