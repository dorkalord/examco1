using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ExamCriterea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamCriterea()
        {
            this.GeneralCritereaImpacts = new HashSet<GeneralCritereaImpact>();
            this.ArgumentCritereas = new HashSet<ArgumentCriterea>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int ExamID { get; set; }
        public int GneralCritereaID { get; set; }


        public virtual GneralCriterea GneralCriterea { get; set; }
        public virtual Exam Exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralCritereaImpact> GeneralCritereaImpacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgumentCriterea> ArgumentCritereas { get; set; }
    }
}
