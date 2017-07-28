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
            this.ExamCriterea = new HashSet<ExamCriterea>();
            this.ExamAttempts = new HashSet<ExamAttempt>();
            this.Questions = new HashSet<Question>();
            this.Grades = new HashSet<Grade>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public int StateID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Censor> Censors { get; set; }
        
        public virtual Course Course { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamCriterea> ExamCriterea { get; set; }
        
        public virtual User Author { get; set; }
        public virtual State State { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAttempt> ExamAttempts { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
