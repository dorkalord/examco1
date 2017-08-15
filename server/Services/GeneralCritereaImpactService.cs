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
    public interface IGeneralCritereaImpactService : IService<GeneralCritereaImpact>
    {
        List<GeneralCritereaImpact> CreateMany(List<GeneralCritereaImpact> many);
        IEnumerable<GeneralCritereaImpact> GetByExamAttempt(int examID);
    }

    public class GeneralCritereaImpactService : IGeneralCritereaImpactService
    {
        private DataContext _context;

        public GeneralCritereaImpactService(DataContext context)
        {
            _context = context;
        }

        public GeneralCritereaImpact Create(GeneralCritereaImpact newObject)
        {
            if (newObject.MistakeID < 0)
            {
                Mistake m = _context.Mistakes.First(x => x.AnwserID == newObject.AnwserID && x.ArgumentID == (newObject.MistakeID * -1));
                if (m == null)
                {
                    throw new AppException("When inserting general criteria the realted mistake was not found");
                }
                newObject.MistakeID = m.ID;
            }


            _context.GeneralCritereaImpacts.Add(newObject);
            _context.SaveChanges();

            return _context.GeneralCritereaImpacts.Last();
        }

        public List<GeneralCritereaImpact> CreateMany(List<GeneralCritereaImpact> many)
        {
            List<GeneralCritereaImpact> newList = new List<GeneralCritereaImpact>();
            foreach (GeneralCritereaImpact item in many)
            {
                newList.Add(_context.GeneralCritereaImpacts.Add(item).Entity);
            }
            _context.SaveChanges();
            return newList;
        }

        public void Delete(int id)
        {
            GeneralCritereaImpact x = _context.GeneralCritereaImpacts.Find(id);
            if (x != null)
            {
                _context.GeneralCritereaImpacts.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<GeneralCritereaImpact> GetAll()
        {
            return _context.GeneralCritereaImpacts;
        }

        public GeneralCritereaImpact GetById(int id)
        {
            return _context.GeneralCritereaImpacts.Find(id);
        }

        public IEnumerable<GeneralCritereaImpact> GetByExamAttempt(int examID)
        {
            return _context.GeneralCritereaImpacts.Where(x => x.ExamAttemptID == examID);
        }

        public GeneralCritereaImpact Update(GeneralCritereaImpact updatedObject)
        {
            GeneralCritereaImpact x = _context.GeneralCritereaImpacts.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("GeneralCritereaImpact not found");

            /*copy properties here*/
            x.Weight = updatedObject.Weight;

            _context.GeneralCritereaImpacts.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
