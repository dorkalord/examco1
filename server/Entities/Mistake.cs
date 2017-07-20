using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Mistake
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mistake()
        {
            this.GeneralCritereaImpacts = new HashSet<GeneralCritereaImpact>();
        }
    
        public int ID { get; set; }
        public float AdjustedWeight { get; set; }
        public int ArgumentID { get; set; }
        public int AnwserID { get; set; }
    
        public virtual Anwser Anwser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralCritereaImpact> GeneralCritereaImpacts { get; set; }
        public virtual Argument Argument { get; set; }
    }
}
