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
        Anwser UpdateCompletion(Anwser updatedObject, string completion);
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

            newObject.Completion = "Blank";
            newObject.CensorshipDate = DateTime.Now;
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
            Question q = _context.Questions.Find(t.QuestionID);
            float max = (float)q.Max;
            List<Mistake> list = _context.Mistakes.Where(x => x.AnwserID == t.ID).ToList();
            t.Total = max + (float)t.Adjustment;
            if (list.Count() != 0)
            {
                t.Total = max + (float)t.Adjustment - list.Sum(x => x.AdjustedWeight);
            }
            t.FinalTotal = updatedObject.FinalTotal;
            t.CensorshipDate = DateTime.Now;
            t.Note = updatedObject.Note;
            t.Adjustment = updatedObject.Adjustment;
            t.Completion = updatedObject.Completion;
            
            _context.Anwsers.Update(t);
            _context.SaveChanges();

            return t;
        }

        public Anwser UpdateCompletion(Anwser obj, string completion)
        {
            Anwser t = _context.Anwsers.Find(obj.ID);
            if (t == null)
                throw new AppException("Anwser " + obj.ID + " not found");

            float max = (float)_context.Questions.Find(t.QuestionID).Max;
            t.Completion = completion;

            if (completion == "Attempted")
            {
                if (_context.Mistakes.Where(x => x.AnwserID == obj.ID).Count() != 0)
                {
                    t.Total = (float) (max - (float) (_context.Mistakes.Where(x => x.AnwserID == obj.ID).Sum(x => x.AdjustedWeight)));
                }
                else
                {
                    t.Total = max;
                }

            }
            else
            {
                _context.Mistakes.RemoveRange(_context.Mistakes.Where(x => x.AnwserID == obj.ID));
                _context.GeneralCritereaImpacts.RemoveRange(_context.GeneralCritereaImpacts.Where(x => x.AnwserID == obj.ID));
                t.Adjustment = 0;
                if (completion == "Blank")
                {
                    t.Total = 0;
                }
                else
                {
                    t.Total = max;
                }
            }
            t.CensorshipDate = DateTime.Now;
            _context.Anwsers.Update(t);
            _context.SaveChanges();


            return t;
        }
    }
}
