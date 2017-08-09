using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ExamExport
    {
        public ExamExport()
        {
            this.QuestionArguments = new List<QuestionArgumentExport>();
            this.ArgumentCritereas = new List<ArgumentCritereaExport>();
            this.ExamCritereas = new List<ExamCritereaExport>();
        }
        public List<QuestionArgumentExport> QuestionArguments { get; set; }
        public List<ArgumentCritereaExport> ArgumentCritereas { get; set; }
        public List<ExamCritereaExport> ExamCritereas { get; set; }
    }

    public class QuestionArgumentExport
    {
        public int ExamID { get; set; }
        public string Date { get; set; }
        public string Language { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int QuestionID { get; set; }
        public string QuestionTxt { get; set; }
        public float ProposedWeight { get; set; }
        public float? FinalWeight { get; set; }
        public float MaxPoints { get; set; }
        public int ArgumentID { get; set; }
        public string ArgumentTxt { get; set; }
        public float Weight { get; set; }
        public Boolean Variable { get; set; }
        public string minMistakeText { get; set; }
        public float? minMistakeWeight { get; set; }
        public string maxMistakeText { get; set; }
        public float? maxMistakeWeight { get; set; }

        public QuestionArgumentExport(int examID, string date, string language, int courseID, string courseName, string courseCode,
            int questionID, string questionTxt, float proposedWeight, float? finalWeight, float maxPoints,
            int argumentID, string argumentTxt, float weight, bool variable, string minMistakeText, float? minMistakeWeight, string maxMistakeText, float? maxMistakeWeight)
        {
            ExamID = examID;
            Date = date;
            Language = language;
            CourseID = courseID;
            CourseName = courseName;
            CourseCode = courseCode;
            QuestionID = questionID;
            QuestionTxt = questionTxt;
            ProposedWeight = proposedWeight;
            FinalWeight = finalWeight;
            MaxPoints = maxPoints;
            ArgumentID = argumentID;
            ArgumentTxt = argumentTxt;
            Weight = weight;
            Variable = variable;
            this.minMistakeText = minMistakeText;
            this.minMistakeWeight = minMistakeWeight;
            this.maxMistakeText = maxMistakeText;
            this.maxMistakeWeight = maxMistakeWeight;
        }
    }

    public class ArgumentCritereaExport
    {
        public ArgumentCritereaExport(int questionID, int argumentID, int examCritereaID, int generealcritereaID, float severity)
        {
            QuestionID = questionID;
            ArgumentID = argumentID;
            ExamCritereaID = examCritereaID;
            GenerealcritereaID = generealcritereaID;
            Severity = severity;
        }

        public int QuestionID { get; set; }
        public int ArgumentID { get; set; }
        public int ExamCritereaID { get; set; }
        public int GenerealcritereaID { get; set; }
        public float Severity { get; set; }

    }

    public class ExamCritereaExport
    {
        public ExamCritereaExport(int examCritereaID, int generalCritereaID, string name, string grade, string advice, float min, float max, float top)
        {
            ExamCritereaID = examCritereaID;
            GeneralCritereaID = generalCritereaID;
            Name = name;
            Grade = grade;
            Advice = advice;
            Min = min;
            Max = max;
            Top = top;
        }

        public int ExamCritereaID { get; set; }
        public int GeneralCritereaID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Advice { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public float Top { get; set; }

    }
}
