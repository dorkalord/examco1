using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class GeneralCritereaDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IEnumerable<AdviceDto> Advices { get; set; }
    }

    public class GeneralCritereaSimpleDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
