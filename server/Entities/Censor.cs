using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Censor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Censor()
        {
            this.ExamAttempts = new HashSet<ExamAttempt>();
        }
    
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ExamID { get; set; }
    
        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAttempt> ExamAttempts { get; set; }
    }
}
