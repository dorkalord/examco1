using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ExamFullDto
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public int StateID { get; set; }

        public CourseDto Course { get; set; }
        public UserDto Author { get; set; }
        public StateDto State { get; set; }

        public IEnumerable<CensorDto> Censors { get; set; }
        public IEnumerable<ExamCritereaDto> ExamCriterea { get; set; }

        public IEnumerable<QuestionFullDto> Questions { get; set; }
        public IEnumerable<GradeDto> Grades { get; set; }
    }

    public class ExamListDto
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public int StateID { get; set; }

        public CourseDto Course { get; set; }
        public UserDto Author { get; set; }
        public StateDto State { get; set; }
    }

    public class ExamDto
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public int StateID { get; set; }

        public CourseDto Course { get; set; }
        public UserDto Author { get; set; }

        public IEnumerable<UserDto> Censors { get; set; }
        /*public IEnumerable<ExamCritereaDto> ExamCriterea { get; set; }

        public IEnumerable<ExamQuestionsDto> Questions { get; set; }
        public IEnumerable<GradeDto> Grades { get; set; }*/
    }

    public class ExamCreateDto
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public int StateID { get; set; }

        //public IEnumerable<ExamCritereaDto> ExamCriterea { get; set; }
    }
       
}
