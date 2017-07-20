using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            this.Censors = new HashSet<Censor>();
            this.GeneralCriterea = new HashSet<GeneralCriterea>();
            this.ExamAttempts = new HashSet<ExamAttempt>();
            this.Qestions = new HashSet<Qestion>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Censor> Censors { get; set; }
        
        public virtual Course Course { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralCriterea> GeneralCriterea { get; set; }
        
        public virtual User Author { get; set; }
        
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAttempt> ExamAttempts { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qestion> Qestions { get; set; }
    }
}
