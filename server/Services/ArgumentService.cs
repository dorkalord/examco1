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
    public interface IArgumentService : IService<Argument>
    {
    }

    public class ArgumentService : IArgumentService
    {
        private DataContext _context;

        public ArgumentService(DataContext context)
        {
            _context = context;
        }

        public Argument Create(Argument newObject)
        {
            _context.Arguments.Add(newObject);
            _context.SaveChanges();

            return _context.Arguments.Last(x => x.Text == newObject.Text);
        }

        public void Delete(int id)
        {
            Argument x = _context.Arguments.Find(id);
            if (x != null)
            {
                _context.Arguments.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Argument> GetAll()
        {
            return _context.Arguments;
        }

        public Argument GetById(int id)
        {
            return _context.Arguments.Find(id);
        }

        public Argument Update(Argument updatedObject)
        {
            Argument x = _context.Arguments.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Argument not found");

            /*copy properties here*/
            x.Text              = updatedObject.Text;
            x.Advice            = updatedObject.Advice;
            x.Variable          = updatedObject.Variable;
            x.DefaultWeight     = updatedObject.DefaultWeight;
            x.MinMistakeText    = updatedObject.MinMistakeText;
            x.MinMistakeWeight  = updatedObject.MinMistakeWeight;
            x.MaxMistakeText    = updatedObject.MaxMistakeText;
            x.MaxMistakeWeight  = updatedObject.MaxMistakeWeight;
            x.ParentArgumentID = updatedObject.ParentArgumentID;

            _context.Arguments.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
