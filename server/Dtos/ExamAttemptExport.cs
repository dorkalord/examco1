using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ExamAttemptExport
    {
        public ExamAttemptExport()
        {
            AttemptMistakes = new List<AttemptMistakesExport>();
            AttemptCritereas = new List<AttemptCritereaExport>();
        }
        public List<AttemptMistakesExport> AttemptMistakes { get; set; }
        public List<AttemptCritereaExport> AttemptCritereas { get; set; }
    }
    public class AttemptMistakesExport
    {
        public AttemptMistakesExport(int studentID, int censorID, int examAttemptID, int anwserID, int questionID, float adjustment, int mistakeID, int argumentID, float mistakeDeduction)
        {
            StudentID = studentID;
            CensorID = censorID;
            ExamAttemptID = examAttemptID;
            AnwserID = anwserID;
            QuestionID = questionID;
            Adjustment = adjustment;
            MistakeID = mistakeID;
            ArgumentID = argumentID;
            MistakeDeduction = mistakeDeduction;
        }

        public int StudentID { get; set; }
        public int CensorID { get; set; }
        public int ExamAttemptID { get; set; }
        public int AnwserID { get; set; }
        public int QuestionID { get; set; }
        public float Adjustment { get; set; }
        public int MistakeID { get; set; }
        public int ArgumentID { get; set; }
        public float MistakeDeduction { get; set; }

    }

    public class AttemptCritereaExport
    {
        public AttemptCritereaExport(int studentID, int censorID, int examAttemptID, int? anwserID, int? questionID, int? mistakeID, int? argumentID, int examCritereaID, float weight)
        {
            StudentID = studentID;
            CensorID = censorID;
            ExamAttemptID = examAttemptID;
            AnwserID = anwserID;
            QuestionID = questionID;
            MistakeID = mistakeID;
            ArgumentID = argumentID;
            ExamCritereaID = examCritereaID;
            Weight = weight;
        }

        public int StudentID { get; set; }
        public int CensorID { get; set; }
        public int ExamAttemptID { get; set; }
        public int? AnwserID { get; set; }
        public int? QuestionID { get; set; }
        public int? MistakeID { get; set; }
        public int? ArgumentID { get; set; }
        public int ExamCritereaID { get; set; }
        public float Weight { get; set; }

    }
}
