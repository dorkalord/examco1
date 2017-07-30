using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class StateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Commads { get; set; }

        public Nullable<int> PreviousID { get; set; }
        public Nullable<int> NextID { get; set; }
    }
}
