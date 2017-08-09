using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Services
{
    public interface IExamAttemptService : IService<ExamAttempt>
    {
        IEnumerable<ExamAttempt> getAllForCensorExam(int censorID, int examID);
        ExamAttempt recalculate(ExamAttempt obj);
        ExamAttempt recalculate(int id);

        IEnumerable<ExamAttempt> getAllForExport(int examID);
    }

    public class ExamAttemptService : IExamAttemptService
    {
        private DataContext _context;

        public ExamAttemptService(DataContext context)
        {
            _context = context;
        }
        public ExamAttempt recalculate(int id)
        {
            return this.recalculate(_context.ExamAttempts.Find(id));
        }
        public ExamAttempt recalculate(ExamAttempt obj)
        {
            //TODO
            float sumAttempt = 0;
            obj.Anwsers = _context.Anwsers.Where(x => x.ExamAttemptID == obj.ID).ToArray();
            for (int i = 0; i < obj.Anwsers.Count; i++)
            {
                Anwser item = obj.Anwsers.ElementAt(i);
                Question q = _context.Questions.Find(item.QuestionID);
                float max = (float) q.Max;
                List<Mistake> list = _context.Mistakes.Where(x => x.AnwserID == item.ID).ToList();
                if (list.Count() != 0)
                {
                    item.Total = max - list.Sum(x => x.AdjustedWeight) + (float)item.Adjustment;
                }                
                sumAttempt += item.Total;
                _context.Anwsers.Update(item);
            }

            obj.Total = sumAttempt;
            _context.ExamAttempts.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        public ExamAttempt Create(ExamAttempt newObject)
        {
            if (_context.Censors.Find(newObject.CensorID) == null)
                throw new AppException("Censor not found");
            if (_context.Users.Find(newObject.StudentID) == null)
                throw new AppException("Student not found");
            if (_context.Exams.Find(newObject.ExamID) == null)
                throw new AppException("Exam not found");

            newObject.Total = 0;
            _context.ExamAttempts.Add(newObject);
            _context.SaveChanges();

            newObject = _context.ExamAttempts.Last(x => x.CensorID == newObject.CensorID);
            foreach (Question item in _context.Questions.Where(x => x.ExamID == newObject.ExamID))
            {
                newObject.Anwsers.Add(new Anwser() { Total = 0, QuestionID = item.ID, Adjustment = 0, Completion ="Blank" });
            }

            _context.ExamAttempts.Update(newObject);
            _context.SaveChanges();

            foreach (ExamCriterea item in _context.ExamCritereas.Where(x => x.ExamID == newObject.ExamID))
            {
                _context.GeneralCritereaImpacts.Add(new GeneralCritereaImpact() { Weight = 0, ExamAttemptID = newObject.ID, ExamCritereaID = item.ID });
            }
            _context.SaveChanges();

            return _context.ExamAttempts.Last(x => x.CensorID == newObject.CensorID);
        }

        public void Delete(int id)
        {
            ExamAttempt x = _context.ExamAttempts.Find(id);
            if (x != null)
            {
                _context.ExamAttempts.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ExamAttempt> GetAll()
        {
            return _context.ExamAttempts;
        }

        public IEnumerable<ExamAttempt> getAllForCensorExam(int censorID, int examID)
        {
            return _context.ExamAttempts.Where(x => x.ExamID == examID && x.CensorID == censorID);
        }

        public ExamAttempt GetById(int id)
        {
            ExamAttempt ea = _context.ExamAttempts.Find(id);
            if (ea != null)
            {
                ea.Anwsers = _context.Anwsers.Where(x => x.ExamAttemptID == ea.ID).ToArray();
                for (int i = 0; i < ea.Anwsers.Count; i++)
                {
                    ea.Anwsers.ElementAt(i).Mistakes = _context.Mistakes.Where(x => x.AnwserID == ea.Anwsers.ElementAt(i).ID).ToArray();
                }
                ea.GeneralCritereaImpacts = _context.GeneralCritereaImpacts.Where(x => x.ExamAttemptID == ea.ID).ToArray();
            }
            return ea;
        }

        public ExamAttempt Update(ExamAttempt updatedObject)
        {
            ExamAttempt x = _context.ExamAttempts.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("ExamAttempt not found");

            /*copy properties here*/
            x.CensorshipDate = DateTime.Now;
            x.GradingDate = updatedObject.GradingDate;
            x.GradeID = updatedObject.GradeID;


            _context.ExamAttempts.Update(x);
            _context.SaveChanges();

            x = this.recalculate(x);
            return x;
        }

        public IEnumerable<ExamAttempt> getAllForExport(int examID)
        {
            List<ExamAttempt> list = _context.ExamAttempts.Where(x=> x.ExamID == examID).ToList();

            for (int i = 0; i < list.Count; i++)
            { 
                list[i].Anwsers = _context.Anwsers.Where(x => x.ExamAttemptID == list[i].ID).ToArray();
                for (int n = 0; n < list[i].Anwsers.Count; n++)
                {
                    list[i].Anwsers.ElementAt(n).Mistakes = _context.Mistakes.
                        Where(x => x.AnwserID == list[i].Anwsers.ElementAt(n).ID).ToArray();
                }
                list[i].GeneralCritereaImpacts = _context.GeneralCritereaImpacts.
                    Where(x => x.ExamAttemptID == list[i].ID).ToArray();
            }
            return list;
        }
    }
}
