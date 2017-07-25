using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class State
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Commads { get; set; }

        public Nullable<int> PreviousID { get; set; }
        public virtual State Previous { get; set; }
        public Nullable<int> NextID { get; set; }
        public virtual State Next { get; set; }
    }
}
