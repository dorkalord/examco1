using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IAnwserService : IService<Anwser>
    {

    }
    public class AnwserService : IAnwserService
    {
        private DataContext _context;

        public AnwserService(DataContext context)
        {
            _context = context;
        }

        public Anwser Create(Anwser newObject)
        {
            if (newObject.ExamAttemptID != null && _context.Anwsers.Find(newObject.ExamAttemptID) == null)
                throw new AppException("Exam attempt " + newObject.ExamAttemptID + " does not exist");

            _context.Anwsers.Add(newObject);
            _context.SaveChanges();

            return _context.Anwsers.Last(x => x.ExamAttemptID == x.ExamAttemptID);
        }

        public void Delete(int id)
        {
            Anwser t = _context.Anwsers.Find(id);
            if (t != null)
            {
                List<Mistake> children = _context.Mistakes.ToList().FindAll(x => x.AnwserID == id);
                foreach (Mistake item in children)
                {
                    this.Delete(item.ID);
                }
                _context.Anwsers.Remove(t);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Anwser> GetAll()
        {
            return _context.Anwsers;
        }

        public Anwser GetById(int id)
        {
            return _context.Anwsers.Find(id);
        }

        public Anwser Update(Anwser updatedObject)
        {
            Anwser t = _context.Anwsers.Find(updatedObject.ID);
            if (t == null)
                throw new AppException("Anwser " + updatedObject.ID + " not found");

            /*copy properties here*/
            t.Total = updatedObject.Total;
            t.FinalTotal = updatedObject.FinalTotal;
            t.CensorshipDate = DateTime.Now;
            t.Note = t.Note;

            _context.Anwsers.Update(t);
            _context.SaveChanges();

            return t;
        }
    }
}
