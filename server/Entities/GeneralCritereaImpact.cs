using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class GeneralCritereaImpact
    {
        public int ID { get; set; }
        public int ExamAttemptID { get; set; }
        public Nullable<int> AnwserID { get; set; }
        public Nullable<int> MistakeID { get; set; }
        public int ExamCritereaID { get; set; }
        public float Weight { get; set; }
    
        public virtual Anwser Anwser { get; set; }
        public virtual ExamCriterea ExamCriterea { get; set; }
        public virtual ExamAttempt ExamAttempt { get; set; }
        public virtual Mistake Mistake { get; set; }
    }
}
