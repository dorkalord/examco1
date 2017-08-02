using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Anwser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anwser()
        {
            this.GeneralCritereaImpacts = new HashSet<GeneralCritereaImpact>();
            this.Mistakes = new HashSet<Mistake>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> CensorshipDate { get; set; }
        public float Total { get; set; }
        public Nullable<float> FinalTotal { get; set; }
        public string Note { get; set; }
        public int ExamAttemptID { get; set; }
        public int QuestionID { get; set; }
    
        public virtual ExamAttempt ExamAttempt { get; set; }
        public virtual Question Question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralCritereaImpact> GeneralCritereaImpacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mistake> Mistakes { get; set; }
    }
}
