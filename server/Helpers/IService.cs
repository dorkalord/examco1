using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        T Create(T newObject);
        T Update(T updatedObject);
        void Delete(int id);
    }
}
