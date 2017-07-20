using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Exams = new HashSet<Exam>();
            this.Topics = new HashSet<Topic>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int LecturerID { get; set; }
    
        public virtual User Lecturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam> Exams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
