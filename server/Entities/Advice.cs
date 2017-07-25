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
        public int GradeID { get; set; }
        
        public Nullable<int> ExamCritereaID { get; set; }

        public Nullable<int> GneralCritereaID { get; set; }

        public virtual GneralCriterea GneralCriterea { get; set; }

        public virtual ExamCriterea ExamCriterea { get; set; }
        public virtual Grade Grade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAdvice> ExamAdvices { get; set; }
    }
}
