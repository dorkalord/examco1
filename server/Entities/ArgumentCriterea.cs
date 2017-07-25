using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ArgumentCriterea
    {
        public int ID { get; set; }
        public float Severity { get; set; }
        public int ExamCritereaID { get; set; }
        public int ArgumentID { get; set; }
    
        public virtual ExamCriterea ExamCriterea { get; set; }
        public virtual Argument Argument { get; set; }
    }
}
