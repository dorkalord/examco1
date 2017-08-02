using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ExamAttempt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamAttempt()
        {
            this.Anwsers = new HashSet<Anwser>();
            this.GeneralCritereaImpacts = new HashSet<GeneralCritereaImpact>();
            this.ExamAdvices = new HashSet<ExamAdvice>();
        }
    
        public int ID { get; set; }
        public Nullable<float> Total { get; set; }
        public Nullable<float> FinalTotal { get; set; }
        public System.DateTime CensorshipDate { get; set; }
        public Nullable<System.DateTime> GradingDate { get; set; }

        
        public Nullable<int> GradeID { get; set; }
        public int ExamID { get; set; }
        public int CensorID { get; set; }
        public int StudentID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anwser> Anwsers { get; set; }
        public virtual Censor Censor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralCritereaImpact> GeneralCritereaImpacts { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Exam Exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAdvice> ExamAdvices { get; set; }
        public virtual User Setudent { get; set; }
    }
}
