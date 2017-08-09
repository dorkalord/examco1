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

        Exam GetByIdForCensoring(int id);
        Exam GetByIdForExport(int id);
        Exam updateStatus(int examID, int stautsID);
    }
    public class ExamService: IExamService
    {
        private DataContext _context;

        public ExamService(DataContext context)
        {
            _context = context;
        }

        public Exam updateStatus(int examID, int stautsID)
        {
            Exam x = _context.Exams.Find(examID);
            State s = _context.States.Find(stautsID);
            if (x == null)
                throw new AppException("Exam not found");
            if (s == null)
                throw new AppException("Status not found");

            x.StateID = s.ID;
            x.Status = s.Name;

            _context.Exams.Update(x);
            _context.SaveChanges();

            return x;
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
            List<Exam> exams = _context.Exams.Where(x => x.AuthorID == userID).ToList();
            for (int i = 0; i < exams.Count; i++)
            {
                exams[i].Course = _context.Courses.Find(exams[i].CourseID);
                exams[i].State = _context.States.Find(exams[i].StateID);
            }
            return exams;
        }

        public IEnumerable<Exam> GetByCensor(int userID)
        {
            List<Censor> cesorExam = _context.Censors.Where(x => x.UserID == userID).ToList();
            List<Exam> exams = new List<Exam>();
            foreach (Censor item in cesorExam)
            {
                Exam temp = _context.Exams.Find(item.ExamID);
                if (temp.StateID == 2)
                {
                    temp.Course = _context.Courses.Find(temp.CourseID);
                    temp.State = _context.States.Find(temp.StateID);
                    exams.Add(temp);
                }
            }
            return exams;
        }

        public Exam GetById(int id)
        {
            Exam rez = _context.Exams.Find(id);

            if (rez == null)
                throw new AppException("Exam not found");

            rez.Author = _context.Users.Find(rez.AuthorID);
            rez.Course = _context.Courses.Find(rez.CourseID);
            rez.State = _context.States.Find(rez.StateID);
            rez.ExamCriterea = _context.ExamCritereas.Where(x => x.ExamID == id).ToArray();
            rez.Questions = _context.Questions.Where(x => x.ExamID == id).ToArray();
            rez.Censors = _context.Censors.Where(x => x.ExamID == id).ToArray();

            return rez;
        }

        public Exam GetByIdForCensoring(int id)
        {
            Exam rez = _context.Exams.Find(id);

            if (rez == null)
                throw new AppException("Exam not found");

            rez.Author = _context.Users.Find(rez.AuthorID);
            rez.Course = _context.Courses.Find(rez.CourseID);
            rez.Course.Topics = _context.Topics.Where(x => x.CourseID == rez.Course.ID).ToArray();
            rez.State = _context.States.Find(rez.StateID);
            rez.ExamCriterea = _context.ExamCritereas.Where(x => x.ExamID == id).ToArray();
            rez.Questions = _context.Questions.Where(x => x.ExamID == id).ToArray();
            rez.Censors = _context.Censors.Where(x => x.ExamID == id).ToArray();

            for (int i = 0; i < rez.Questions.Count; i++)
            {
                int temp = rez.Questions.ElementAt(i).ID;
                rez.Questions.ElementAt(i).Arguments = _context.Arguments.Where(x => x.QuestionID == temp).ToArray();

                for (int n = 0; n < rez.Questions.ElementAt(i).Arguments.Count; n++)
                {
                    int tempid = rez.Questions.ElementAt(i).Arguments.ElementAt(n).ID;
                    rez.Questions.ElementAt(i).Arguments.ElementAt(n).ArgumentCritereas = _context.ArgumentCritereas.Where(z => z.ArgumentID == tempid).ToArray();
                }

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

        public Exam GetByIdForExport(int id)
        {
            Exam rez = _context.Exams.Find(id);

            if (rez == null)
                throw new AppException("Exam not found");

            rez.Author = _context.Users.Find(rez.AuthorID);
            rez.Course = _context.Courses.Find(rez.CourseID);
            rez.ExamCriterea = _context.ExamCritereas.Where(x => x.ExamID == id).ToArray();
            rez.Questions = _context.Questions.Where(x => x.ExamID == id).ToArray();

            for (int i = 0; i < rez.Questions.Count; i++)
            {
                int temp = rez.Questions.ElementAt(i).ID;
                rez.Questions.ElementAt(i).Arguments = _context.Arguments.Where(x => x.QuestionID == temp).ToArray();

                for (int n = 0; n < rez.Questions.ElementAt(i).Arguments.Count; n++)
                {
                    int tempid = rez.Questions.ElementAt(i).Arguments.ElementAt(n).ID;
                    rez.Questions.ElementAt(i).Arguments.ElementAt(n).ArgumentCritereas = _context.ArgumentCritereas.Where(z => z.ArgumentID == tempid).ToArray();
                }

            }

            for (int n = 0; n < rez.ExamCriterea.Count; n++)
            {
                int tempid = rez.ExamCriterea.ElementAt(n).ID;
                rez.ExamCriterea.ElementAt(n).Advices = _context.Advices.Where(z => z.ExamCritereaID == tempid).ToArray();
            }
            return rez;
        }
    }
}
