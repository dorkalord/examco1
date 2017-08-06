using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class AnwserDto
    {
        public AnwserDto()
        {
            this.Mistakes = new HashSet<MistakeUpdateDto>();
        }

        public int ID { get; set; }
        public Nullable<System.DateTime> CensorshipDate { get; set; }
        public float Total { get; set; }
        public Nullable<float> FinalTotal { get; set; }
        public string Note { get; set; }
        public int ExamAttemptID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<float> Adjustment { get; set; }

        public virtual QuestionDto Question { get; set; }
        public virtual ICollection<MistakeUpdateDto> Mistakes { get; set; }
    }
}
