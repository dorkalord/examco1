using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Qestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Qestion()
        {
            this.Anwsers = new HashSet<Anwser>();
            this.Arguments = new HashSet<Argument>();
            this.ChildQuestions = new HashSet<Qestion>();
            this.Tags = new HashSet<Tag>();
        }
    
        public int ID { get; set; }
        public int SeqencialNumber { get; set; }
        public string Text { get; set; }
        public Nullable<float> ProposedWeight { get; set; }
        public Nullable<float> FinalWeight { get; set; }
        public int ExamID { get; set; }
        public Nullable<int> ParentQuestionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anwser> Anwsers { get; set; }
        public virtual Exam Exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Argument> Arguments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qestion> ChildQuestions { get; set; }
        public virtual Qestion Qestion2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
