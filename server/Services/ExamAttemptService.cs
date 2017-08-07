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
    }

    public class ExamAttemptService : IExamAttemptService
    {
        private DataContext _context;

        public ExamAttemptService(DataContext context)
        {
            _context = context;
        }

        public ExamAttempt Create(ExamAttempt newObject)
        {
            if (_context.Censors.Find(newObject.CensorID) == null)
                throw new AppException("Censor not found");
            if (_context.Users.Find(newObject.StudentID) == null)
                throw new AppException("Student not found");
            if (_context.Exams.Find(newObject.ExamID) == null)
                throw new AppException("Exam not found");

            _context.ExamAttempts.Add(newObject);
            _context.SaveChanges();

            newObject = _context.ExamAttempts.Last(x => x.CensorID == newObject.CensorID);
            foreach (Question item in _context.Questions.Where(x => x.ExamID == newObject.ExamID))
            {
                newObject.Anwsers.Add(new Anwser() { Total = 0, QuestionID = item.ID, Adjustment = 0 });
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
            x.Total = updatedObject.Total;
            x.CensorshipDate = DateTime.Now;
            x.GradingDate = updatedObject.GradingDate;
            x.GradeID = updatedObject.GradeID;


            _context.ExamAttempts.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
