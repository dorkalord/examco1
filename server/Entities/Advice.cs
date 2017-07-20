using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Advice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Advice()
        {
            this.ExamAdvices = new HashSet<ExamAdvice>();
        }
    
        public int ID { get; set; }
        public string Text { get; set; }
        public string Grade { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public Nullable<int> GeneralCritereaID { get; set; }
    
        public virtual GeneralCriterea GeneralCriterea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAdvice> ExamAdvices { get; set; }
    }
}
