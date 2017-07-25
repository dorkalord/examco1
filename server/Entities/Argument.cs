using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Argument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Argument()
        {
            this.ChildrenArguments = new HashSet<Argument>();
            this.ArgumentCritereas = new HashSet<ArgumentCriterea>();
            this.Mistakes = new HashSet<Mistake>();
        }
    
        public int ID { get; set; }
        public string Advice { get; set; }
        public string Text { get; set; }
        public bool Variable { get; set; }
        public string MinMistakeText { get; set; }
        public string MaxMistakeText { get; set; }
        public Nullable<float> MinMistakeWeight { get; set; }
        public Nullable<float> MaxMistakeWeight { get; set; }
        public Nullable<float> DefaultWeight { get; set; }
        public Nullable<int> ParentArgumentIID { get; set; }
        public int QestionID { get; set; }
        public Nullable<int> AuthorID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Argument> ChildrenArguments { get; set; }
        public virtual Argument ParentArgument { get; set; }
        public virtual Qestion Qestion { get; set; }
        public virtual User Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArgumentCriterea> ArgumentCritereas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mistake> Mistakes { get; set; }
    }
}
