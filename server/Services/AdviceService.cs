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
    public interface IAdviceService : IService<Advice>
    {
        IEnumerable<Advice> getByCriterea(int id);
    }

    public class AdviceService: IAdviceService
    {
        private DataContext _context;

        public AdviceService(DataContext context)
        {
            _context = context;
        }

        public Advice Create(Advice newObject)
        {
            if (_context.Advices.Any(x => x.Grade == newObject.Grade  && x.ExamCritereaID == newObject.ExamCritereaID))
                throw new AppException("Advice grade " + newObject.Grade + " is already taken");

            _context.Advices.Add(newObject);
            _context.SaveChanges();

            return _context.Advices.First(x => x.Grade == newObject.Grade && x.ExamCritereaID == newObject.ExamCritereaID);
        }

        public void Delete(int id)
        {
            Advice x = _context.Advices.Find(id);
            if (x != null)
            {
                _context.Advices.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Advice> GetAll()
        {
            return _context.Advices;
        }

        public IEnumerable<Advice> getByCriterea(int id)
        {
            return _context.Advices.ToList().FindAll(x => x.GeneralCritereaID == id);
        }

        public Advice GetById(int id)
        {
            return _context.Advices.Find(id);
        }

        public Advice Update(Advice updatedObject)
        {
            Advice x = _context.Advices.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Advice not found");

            /*copy properties here*/
            x.Text = updatedObject.Text;
            x.Grade = updatedObject.Grade;
            x.Min = updatedObject.Min;
            x.Max = updatedObject.Max;
            x.Top = updatedObject.Top;

            _context.Advices.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
