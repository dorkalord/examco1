using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ArgumentCriterea
    {
        public int ID { get; set; }
        public float Severity { get; set; }
        public int GeneralCritereaID { get; set; }
        public int ArgumentID { get; set; }
    
        public virtual GeneralCriterea GeneralCriterea { get; set; }
        public virtual Argument Argument { get; set; }
    }
}
