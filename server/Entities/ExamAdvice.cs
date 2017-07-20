using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ExamAdvice
    {
        public int ID { get; set; }
        public int AttemptID { get; set; }
        public int AdviceID { get; set; }
        public int GeneralCritereaID { get; set; }
    
        public virtual GeneralCriterea GeneralCriterea { get; set; }
        public virtual Advice Advice { get; set; }
        public virtual ExamAttempt ExamAttempt { get; set; }
    }
}
