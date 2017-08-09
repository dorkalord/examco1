using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Dtos;

namespace WebApi.Entities
{
    public class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            this.Censors = new HashSet<Censor>();
            this.ExamCriterea = new HashSet<ExamCriterea>();
            this.ExamAttempts = new HashSet<ExamAttempt>();
            this.Questions = new HashSet<Question>();
            this.Grades = new HashSet<Grade>();
        }
    
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int AuthorID { get; set; }
        public int CourseID { get; set; }
        public int StateID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Censor> Censors { get; set; }
        
        public virtual Course Course { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamCriterea> ExamCriterea { get; set; }
        
        public virtual User Author { get; set; }
        public virtual State State { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamAttempt> ExamAttempts { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grade> Grades { get; set; }

        public String toCSV()
        {
            string info = ID + ';' + this.Date.ToString("dd.MM.yyyy hh:mm") + ';' + Language + ';' + CourseID + ';' + Course.Name + ';' + Course.Code;
            return info;
        }

        public ExamExport export()
        {
            ExamExport data = new ExamExport();
            
            foreach (Question q in Questions)
            {
                foreach (Argument a in q.Arguments)
                {
                    data.QuestionArguments.Add(new QuestionArgumentExport(ID, this.Date.ToString("dd.MM.yyyy hh:mm"), Language, CourseID, Course.Name, Course.Code,
                                                q.ID, q.Text, (float)q.ProposedWeight, q.FinalWeight, (float)q.Max,
                                                    a.ID, a.Text, (float)a.DefaultWeight, a.Variable, a.MinMistakeText, a.MinMistakeWeight, a.MaxMistakeText, a.MaxMistakeWeight));
                    foreach (ArgumentCriterea ac in a.ArgumentCritereas)
                    {
                        data.ArgumentCritereas.Add(new ArgumentCritereaExport(q.ID, a.ID, ac.ExamCritereaID,
                            this.ExamCriterea.ToList().Find(x => x.ID == ac.ExamCritereaID).GeneralCritereaID, ac.Severity));
                    }
                }
            }

            foreach (ExamCriterea ec in ExamCriterea)
            {
                foreach (Advice a in ec.Advices)
                {
                    data.ExamCritereas.Add(new ExamCritereaExport(ec.ID, ec.GeneralCritereaID, ec.Name,
                        a.Grade, a.Text, a.Min, a.Max, a.Top));
                }
            }

            return data;
        }

    }
}
