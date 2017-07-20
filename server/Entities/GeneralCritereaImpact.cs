using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class GeneralCritereaImpact
    {
        public int ID { get; set; }
        public int AttemptID { get; set; }
        public Nullable<int> AnwserID { get; set; }
        public Nullable<int> MistakeID { get; set; }
        public int GeneralCritereaID { get; set; }
        public float Weight { get; set; }
    
        public virtual Anwser Anwser { get; set; }
        public virtual GeneralCriterea GeneralCriterea { get; set; }
        public virtual ExamAttempt ExamAttempt { get; set; }
        public virtual Mistake Mistake { get; set; }
    }
}
