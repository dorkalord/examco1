using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ExamAttemptFullDto
    {
        public ExamAttemptFullDto()
        {
            this.Anwsers = new HashSet<AnwserDto>();
            this.GeneralCritereaImpacts = new HashSet<GeneralCritereaImpactDto>();
            this.ExamAdvices = new HashSet<ExamAdviceDto>();
        }

        public int ID { get; set; }
        public Nullable<float> Total { get; set; }
        public Nullable<float> FinalTotal { get; set; }
        public System.DateTime CensorshipDate { get; set; }
        public Nullable<System.DateTime> GradingDate { get; set; }

        public Nullable<int> GradeID { get; set; }
        public int ExamID { get; set; }
        public int CensorID { get; set; }
        public int StudentID { get; set; }

        public virtual ICollection<AnwserDto> Anwsers { get; set; }
        public virtual CensorDto Censor { get; set; }
        public virtual ICollection<GeneralCritereaImpactDto> GeneralCritereaImpacts { get; set; }
        public virtual GradeDto Grade { get; set; }
        public virtual ExamDto Exam { get; set; }
        public virtual ICollection<ExamAdviceDto> ExamAdvices { get; set; }
        public virtual UserDto Setudent { get; set; }
    }

    public class ExamAttemptDto
    {
        public int ID { get; set; }
        public Nullable<float> Total { get; set; }
        public Nullable<float> FinalTotal { get; set; }
        public System.DateTime CensorshipDate { get; set; }
        public Nullable<System.DateTime> GradingDate { get; set; }


        public Nullable<int> GradeID { get; set; }
        public int ExamID { get; set; }
        public int CensorID { get; set; }
        public int StudentID { get; set; }

        public virtual GradeDto Grade { get; set; }
        public virtual UserDto Setudent { get; set; }
    }

    public class ExamAttemptCreateDto
    {
        public int ExamID { get; set; }
        public int CensorID { get; set; }
        public int StudentID { get; set; }
    }
}
