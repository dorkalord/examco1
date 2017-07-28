using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Grade
    {
        public Grade()
        {
            this.ExamAttempt = new HashSet<ExamAttempt>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public float Min { get; set; }
        public float Max { get; set; }
        public float Top { get; set; }

        public Nullable<int> ExamID { get; set; }
        public virtual Exam Exam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAttempt> ExamAttempt { get; set; }
    }
}
