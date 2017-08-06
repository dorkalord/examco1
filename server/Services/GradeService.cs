using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IGradeService : IService<Grade>
    {
        IEnumerable<Grade> getByExam(int examID);
    }

    public class GradeService: IGradeService
    {
        private DataContext _context;

        public GradeService(DataContext context)
        {
            _context = context;
        }

        public Grade Create(Grade newObject)
        {
            _context.Grades.Add(newObject);
            _context.SaveChanges();

            return _context.Grades.Last(x => x.Name == newObject.Name);
        }

        public void Delete(int id)
        {
            Grade x = _context.Grades.Find(id);
            if (x != null)
            {
                _context.Grades.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Grade> GetAll()
        {
            return _context.Grades;
        }

        public IEnumerable<Grade> getByExam(int examID)
        {
            Exam x = _context.Exams.Find(examID);
            if (x == null)
                throw new AppException("Exam not found");

            return x.Grades;
        }

        public Grade GetById(int id)
        {
            return _context.Grades.Find(id);
        }

        public Grade Update(Grade updatedObject)
        {
            Grade x = _context.Grades.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Grade not found");

            /*copy properties here*/
            x.Max = updatedObject.Max;
            x.Min = updatedObject.Min;
            x.Name = updatedObject.Name;
            x.Top = updatedObject.Top;

            _context.Grades.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
