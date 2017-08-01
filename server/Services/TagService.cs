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
    public interface ITagService : IService<Tag>
    {
    }

    public class TagService : ITagService
    {
        private DataContext _context;

        public TagService(DataContext context)
        {
            _context = context;
        }

        public Tag Create(Tag newObject)
        {
            _context.Tags.Add(newObject);
            _context.SaveChanges();

            return _context.Tags.Last(x => x.TopicID == newObject.TopicID);
        }

        public void Delete(int id)
        {
            Tag x = _context.Tags.Find(id);
            if (x != null)
            {
                _context.Tags.Remove(x);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags;
        }

        public Tag GetById(int id)
        {
            return _context.Tags.Find(id);
        }

        public Tag Update(Tag updatedObject)
        {
            Tag x = _context.Tags.Find(updatedObject.ID);
            if (x == null)
                throw new AppException("Tag not found");

            /*copy properties here*/
            x.QuestionID = updatedObject.QuestionID;
            x.TopicID = updatedObject.TopicID;

            _context.Tags.Update(x);
            _context.SaveChanges();

            return x;
        }
    }
}
