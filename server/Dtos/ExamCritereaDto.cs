using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ExamCritereaDto
    {
        public Nullable<int> ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> GeneralCritereaID { get; set; }

        public IEnumerable<AdviceDto> Advices { get; set; }
    }
}
