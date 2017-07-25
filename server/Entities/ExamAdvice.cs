using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ExamAdvice
    {
        public int ID { get; set; }
        public int AttemptID { get; set; }
        public int AdviceID { get; set; }
        public int ExamCritereaID { get; set; }
    
        public virtual ExamCriterea ExamCriterea { get; set; }
        public virtual Advice Advice { get; set; }
        public virtual ExamAttempt ExamAttempt { get; set; }
    }
}
