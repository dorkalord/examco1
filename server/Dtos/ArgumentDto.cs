using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ArgumentDto
    {
        public string Advice { get; set; }
        public string Text { get; set; }
        public bool Variable { get; set; }
        public string MinMistakeText { get; set; }
        public string MaxMistakeText { get; set; }
        public Nullable<float> MinMistakeWeight { get; set; }
        public Nullable<float> MaxMistakeWeight { get; set; }
        public Nullable<float> DefaultWeight { get; set; }
        public Nullable<int> ParentArgumentID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<int> AuthorID { get; set; }

        public IEnumerable<ArgumentCritereaDto> ArgumentCritereas { get; set; }
    }

    public class ArgumentCreateDto
    {
        public string Advice { get; set; }
        public string Text { get; set; }
        public bool Variable { get; set; }
        public string MinMistakeText { get; set; }
        public string MaxMistakeText { get; set; }
        public Nullable<float> MinMistakeWeight { get; set; }
        public Nullable<float> MaxMistakeWeight { get; set; }
        public Nullable<float> DefaultWeight { get; set; }
        public int QuestionID { get; set; }
        public Nullable<int> AuthorID { get; set; }

        public IEnumerable<ArgumentCritereaDto> ArgumentCritereas { get; set; }
    }

    public class ArgumentFullDto
    {
        public string ID { get; set; }
        public string Advice { get; set; }
        public string Text { get; set; }
        public bool Variable { get; set; }
        public string MinMistakeText { get; set; }
        public string MaxMistakeText { get; set; }
        public Nullable<float> MinMistakeWeight { get; set; }
        public Nullable<float> MaxMistakeWeight { get; set; }
        public Nullable<float> DefaultWeight { get; set; }
        public Nullable<int> ParentArgumentID { get; set; }
        public int QuestionID { get; set; }
        public Nullable<int> AuthorID { get; set; }

        public IEnumerable<ArgumentCritereaFullDto> ArgumentCritereas { get; set; }
    }
}
