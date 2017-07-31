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
    public interface IExamCritereaService : IService<ExamCriterea>
    {
        IEnumerable<ExamCriterea> getByExam(int examID);
    }

    public class ExamCritereaService : IExamCritereaService
    {
        private DataContext _context;

        public ExamCritereaService(DataContext context)
        {
            _context = context;
        }

        public ExamCriterea Create(ExamCriterea newObject)
        {
            _context.ExamCritereas.Add(newObject);
            _context.SaveChanges();

            return _context.ExamCritereas.Last(x => x.Name == newObject.Name);
        }

        public void Delete(int id)
        {
            ExamCriterea x = _context.ExamCritereas.Find(id);
            if (x != null)
            {
                _context.ExamCritereas.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ExamCriterea> GetAll()
        {
            return _context.ExamCritereas;
        }

        public IEnumerable<ExamCriterea> getByExam(int examID)
        {
            return _context.ExamCritereas.Where(x => x.ExamID == examID);
        }

        public ExamCriterea GetById(int id)
        {
            return _context.ExamCritereas.Find(id);
        }

        public ExamCriterea Update(ExamCriterea updatedObject)
        {
            ExamCriterea x = _context.ExamCritereas.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("ExamCriterea not found");

            /*copy properties here*/
            x.Name = updatedObject.Name;
            x.GeneralCritereaID = updatedObject.GeneralCritereaID;


            _context.ExamCritereas.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
