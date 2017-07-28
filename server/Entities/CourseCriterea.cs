using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class CourseCriterea
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int GeneralCritereaID { get; set; }


        public virtual GeneralCriterea GeneralCriterea { get; set; }
        public virtual Course Course { get; set; }
    }
}
