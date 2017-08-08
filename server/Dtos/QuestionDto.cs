using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            this.Tags = new HashSet<TagDto>();
            this.Arguments = new HashSet<ArgumentDto>();
        }

        public int SeqencialNumber { get; set; }
        public string Text { get; set; }
        public Nullable<float> ProposedWeight { get; set; }
        public Nullable<float> FinalWeight { get; set; }
        public Nullable<float> Max { get; set; }
        public int ExamID { get; set; }
        public Nullable<int> ParentQuestionID { get; set; }
        

        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<ArgumentDto> Arguments { get; set; }
    }

    public class QuestionFullDto
    {
        public QuestionFullDto()
        {
            this.Tags = new HashSet<TagDto>();
            this.Arguments = new HashSet<ArgumentFullDto>();
        }

        public int ID { get; set; }
        public int SeqencialNumber { get; set; }
        public string Text { get; set; }
        public Nullable<float> ProposedWeight { get; set; }
        public Nullable<float> FinalWeight { get; set; }
        public Nullable<float> Max { get; set; }
        public int ExamID { get; set; }
        public Nullable<int> ParentQuestionID { get; set; }


        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<ArgumentFullDto> Arguments { get; set; }
    }

    public class QuestionCreateDto
    {
        public QuestionCreateDto()
        {
            this.Tags = new HashSet<TagDto>();
            this.Arguments = new HashSet<ArgumentCreateDto>();
        }

        
        public int SeqencialNumber { get; set; }
        public string Text { get; set; }
        public Nullable<float> ProposedWeight { get; set; }
        public Nullable<float> FinalWeight { get; set; }
        public Nullable<float> Max { get; set; }
        public int ExamID { get; set; }


        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<ArgumentCreateDto> Arguments { get; set; }
    }
}
