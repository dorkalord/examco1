using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMistakeService : IService<Mistake>
    {
        IEnumerable<Mistake> getByAnwser(int AnwserID);
    }
    public class MistakeService : IMistakeService
    {
        private DataContext _context;

        public MistakeService(DataContext context)
        {
            _context = context;
        }

        public Mistake Create(Mistake newObject)
        {
            if ( _context.Anwsers.Find(newObject.AnwserID) == null)
                throw new AppException("Parrent anwser " + newObject.AnwserID + " does not exist");

            _context.Mistakes.Add(newObject);
            _context.SaveChanges();

            return _context.Mistakes.Last(x => x.AnwserID == newObject.AnwserID);
        }

        public void Delete(int id)
        {
            Mistake t = _context.Mistakes.Find(id);
            if (t != null)
            {
                _context.GeneralCritereaImpacts.RemoveRange(_context.GeneralCritereaImpacts.Where(x => x.MistakeID == id));
                _context.Mistakes.Remove(t);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Mistake> GetAll()
        {
            return _context.Mistakes;
        }

        public IEnumerable<Mistake> getByAnwser(int AnwserID)
        {
            return _context.Mistakes.ToList().FindAll(x => x.AnwserID == AnwserID);
        }

        public Mistake GetById(int id)
        {
            return _context.Mistakes.Find(id);
        }

        public Mistake Update(Mistake updatedObject)
        {
            Mistake t = _context.Mistakes.Find(updatedObject.ID);
            if (t == null)
                throw new AppException("Mistake " + updatedObject.ID + " not found");

            /*copy properties here*/
            t.AdjustedWeight = updatedObject.AdjustedWeight;

            _context.Mistakes.Update(t);
            _context.SaveChanges();

            return t;
        }
    }
}
