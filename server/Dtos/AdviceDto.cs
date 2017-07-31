using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class AdviceDto
    {
        public Nullable<int> ID { get; set; }
        public string Text { get; set; }

        public string Grade { get; set; }

        public float Min { get; set; }
        public float Max { get; set; }
        public float Top { get; set; }

    }
}
