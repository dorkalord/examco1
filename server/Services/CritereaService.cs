using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
namespace WebApi.Services
{
    public interface IGeneralCritereaService : IService<GeneralCriterea>
    {
    }


    public class GeneralCritereaService: IGeneralCritereaService
    {
        private DataContext _context;

        public GeneralCritereaService(DataContext context)
        {
            _context = context;
        }

        public GeneralCriterea Create(GeneralCriterea newObject)
        {
            if (_context.GeneralCritereas.Any(x => x.Name == newObject.Name ))
                throw new AppException("GeneralCriterea Name " + newObject.Name + " is already taken");

            _context.GeneralCritereas.Add(newObject);
            _context.SaveChanges();

            return _context.GeneralCritereas.First(x => x.Name == newObject.Name);
        }

        public void Delete(int id)
        {
            GeneralCriterea x = _context.GeneralCritereas.Find(id);
            if (x != null)
            {
                _context.GeneralCritereas.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<GeneralCriterea> GetAll()
        {
            return _context.GeneralCritereas;
        }

        public GeneralCriterea GetById(int id)
        {
            return _context.GeneralCritereas.Find(id);
        }

        public GeneralCriterea Update(GeneralCriterea updatedObject)
        {
            GeneralCriterea x = _context.GeneralCritereas.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("GeneralCriterea not found");

            /*copy properties here*/
            x.Name = updatedObject.Name;

            _context.GeneralCritereas.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
