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
            _context.ExamAttempts.Add(newObject);
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
            return _context.ExamAttempts.Find(id);
        }

        public ExamAttempt Update(ExamAttempt updatedObject)
        {
            ExamAttempt x = _context.ExamAttempts.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("ExamAttempt not found");

            /*copy properties here*/
            x.Total = updatedObject.Total;
            x.CensorshipDate = updatedObject.CensorshipDate;
            x.GradingDate = updatedObject.GradingDate;
            x.GradeID = updatedObject.GradeID;

            _context.ExamAttempts.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
