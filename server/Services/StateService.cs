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
    public interface IStateService : IService<State>
    {
    }

    public class StateService : IStateService
    {
        private DataContext _context;

        public StateService(DataContext context)
        {
            _context = context;
        }

        public State Create(State newObject)
        {
            _context.States.Add(newObject);
            _context.SaveChanges();

            return _context.States.Last(x => x.Name == newObject.Name);
        }

        public void Delete(int id)
        {
            State x = _context.States.Find(id);
            if (x != null)
            {
                _context.States.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<State> GetAll()
        {
            return _context.States;
        }

        public State GetById(int id)
        {
            return _context.States.Find(id);
        }

        public State Update(State updatedObject)
        {
            State x = _context.States.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("State not found");

            /*copy properties here*/
            x.Name = updatedObject.Name;
            x.NextID = updatedObject.NextID;
            x.PreviousID = updatedObject.PreviousID;
            x.Commads = updatedObject.Commads;

            _context.States.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
