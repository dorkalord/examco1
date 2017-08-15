using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
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

            _context.Mistakes.RemoveRange(_context.Mistakes.Where(x => x.AnwserID == updatedObject.ID));
            _context.GeneralCritereaImpacts.RemoveRange(_context.GeneralCritereaImpacts.Where(x => x.AnwserID == updatedObject.ID && x.MistakeID != null));
            _context.SaveChanges();

            /*copy properties here*/
            Question q = _context.Questions.Find(t.QuestionID);
            float max = (float)q.Max;
            //List<Mistake> list = _context.Mistakes.Where(x => x.AnwserID == t.ID).ToList();
            t.Adjustment = updatedObject.Adjustment;
            t.Total = max;
            

            foreach (Mistake item in updatedObject.Mistakes)
            {
                Mistake temp = new Mistake() { AnwserID = t.ID, ArgumentID = item.ArgumentID, AdjustedWeight = item.AdjustedWeight };
                _context.Mistakes.Add(temp);
                _context.SaveChanges();
                temp = _context.Mistakes.Last(x => x.AnwserID == t.ID);

                foreach (ArgumentCriterea ac in _context.ArgumentCritereas.Where(x=> x.ArgumentID == item.ArgumentID))
                {
                    GeneralCritereaImpact tempgc = new GeneralCritereaImpact() { ExamAttemptID = t.ExamAttemptID, AnwserID = t.ID, MistakeID = temp.ID, ExamCritereaID = ac.ExamCritereaID, Weight = ac.Severity };
                    _context.GeneralCritereaImpacts.Add(tempgc);
                }

                t.Total += item.AdjustedWeight;
                _context.SaveChanges();
            }

            if (t.Total + t.Adjustment > max)
            {
                t.Adjustment = max - t.Total;
                t.Total = max;
            }
            else
            {
                t.Total += (float)t.Adjustment;
            }

            t.FinalTotal = updatedObject.FinalTotal;
            t.CensorshipDate = DateTime.Now;
            t.Note = updatedObject.Note;
            
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
                    t.Total = (float) (max - (float) (_context.Mistakes.Where(x => x.AnwserID == obj.ID).Sum(x => x.AdjustedWeight))) + (float)t.Adjustment;
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
                t.Adjustment = 0;
            }
            t.CensorshipDate = DateTime.Now;
            _context.Anwsers.Update(t);
            _context.SaveChanges();


            return t;
        }
    }
}
