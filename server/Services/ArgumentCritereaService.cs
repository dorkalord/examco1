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
    public interface IArgumentCritereaService : IService<ArgumentCriterea>
    {
    }

    public class ArgumentCritereaService : IArgumentCritereaService
    {
        private DataContext _context;

        public ArgumentCritereaService(DataContext context)
        {
            _context = context;
        }

        public ArgumentCriterea Create(ArgumentCriterea newObject)
        {
            _context.ArgumentCritereas.Add(newObject);
            _context.SaveChanges();

            return _context.ArgumentCritereas.Last(x => x.ExamCritereaID == newObject.ExamCritereaID);
        }

        public void Delete(int id)
        {
            ArgumentCriterea x = _context.ArgumentCritereas.Find(id);
            if (x != null)
            {
                _context.ArgumentCritereas.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ArgumentCriterea> GetAll()
        {
            return _context.ArgumentCritereas;
        }

        public ArgumentCriterea GetById(int id)
        {
            return _context.ArgumentCritereas.Find(id);
        }

        public ArgumentCriterea Update(ArgumentCriterea updatedObject)
        {
            ArgumentCriterea x = _context.ArgumentCritereas.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("ArgumentCriterea not found");

            /*copy properties here*/
            x.Severity = updatedObject.Severity;

            _context.ArgumentCritereas.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
