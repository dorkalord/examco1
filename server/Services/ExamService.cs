using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IExamService : IService<Exam>
    {
        IEnumerable<Exam> getByAuthor(int userID);
        IEnumerable<Exam> GetByCensor(int userID);
        IEnumerable<Exam> GetByStudent(int userID);
    }
    public class ExamService: IExamService
    {
        private DataContext _context;

        public ExamService(DataContext context)
        {
            _context = context;
        }

        public Exam Create(Exam newObject)
        {
            _context.Exams.Add(newObject);
            _context.SaveChanges();

            return _context.Exams.Last(x => x.CourseID == newObject.CourseID);
        }

        public void Delete(int id)
        {
            Exam x = _context.Exams.Find(id);
            if (x != null)
            {
                _context.Exams.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Exam> GetAll()
        {
            return _context.Exams;
        }

        public IEnumerable<Exam> getByAuthor(int userID)
        {
            return _context.Exams.Where(x => x.AuthorID == userID);
        }

        public IEnumerable<Exam> GetByCensor(int userID)
        {
            throw new NotImplementedException();
        }

        public Exam GetById(int id)
        {
            Exam rez = _context.Exams.Find(id);
            
            if(rez != null)
            {
                rez.Author = _context.Users.Find(rez.AuthorID);
                rez.Course = _context.Courses.Find(rez.CourseID);
                rez.State = _context.States.Find(rez.StateID);
                rez.ExamCriterea = _context.ExamCritereas.Where(x => x.ExamID == id).ToList();
                rez.Questions = _context.Questions.Where(x => x.ExamID == id).ToList();
            }

            return rez;
        }

        public IEnumerable<Exam> GetByStudent(int userID)
        {
            throw new NotImplementedException();
        }

        public Exam Update(Exam updatedObject)
        {
            Exam x = _context.Exams.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Exam not found");

            /*copy properties here*/
            x.AuthorID = updatedObject.AuthorID;
            x.CourseID = updatedObject.CourseID;
            x.Date = updatedObject.Date;
            x.Language = updatedObject.Language;
            x.StateID = updatedObject.StateID;
            x.Status = updatedObject.Status;

            _context.Exams.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
