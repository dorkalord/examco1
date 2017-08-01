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
    public interface ICensorService : IService<Censor>
    {
        List<Censor> CreateMany(List<Censor> many);
    }

    public class CensorService : ICensorService
    {
        private DataContext _context;

        public CensorService(DataContext context)
        {
            _context = context;
        }

        public Censor Create(Censor newObject)
        {
            _context.Censors.Add(newObject);
            _context.SaveChanges();

            return _context.Censors.Last();
        }

        public List<Censor> CreateMany(List<Censor> many)
        {
            List<Censor> newList = new List<Censor>();
            foreach (Censor item in many)
            {
                newList.Add(_context.Censors.Add(item).Entity);
            }
            _context.SaveChanges();
            return newList;
        }

        public void Delete(int id)
        {
            Censor x = _context.Censors.Find(id);
            if (x != null)
            {
                _context.Censors.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Censor> GetAll()
        {
            return _context.Censors;
        }

        public Censor GetById(int id)
        {
            return _context.Censors.Find(id);
        }

        public Censor Update(Censor updatedObject)
        {
            Censor x = _context.Censors.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Censor not found");

            /*copy properties here*/
            

            _context.Censors.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
