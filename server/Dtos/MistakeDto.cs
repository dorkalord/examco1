using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class MistakeDto
    {
        public int ID { get; set; }
        public float AdjustedWeight { get; set; }
        public int ArgumentID { get; set; }
        public int AnwserID { get; set; }

        public virtual ArgumentDto Argument { get; set; }
    }

    public class MistakeUpdateDto
    {
        public int ID { get; set; }
        public float AdjustedWeight { get; set; }
        public int ArgumentID { get; set; }
        public int AnwserID { get; set; }

    }

    public class MistakeCreateDto
    {
        public float AdjustedWeight { get; set; }
        public int ArgumentID { get; set; }
        public int AnwserID { get; set; }

    }
}
