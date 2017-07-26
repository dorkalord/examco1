using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ITopicService : IService<Topic>
    {
        IEnumerable<Topic> getByCourse(int courseID);
    }
    public class TopicService : ITopicService
    {
        private DataContext _context;

        public TopicService(DataContext context)
        {
            _context = context;
        }

        public Topic Create(Topic newObject)
        {
            /*if (_context.Topics.Any(x => x.Name == newObject.Name ))
                throw new AppException("Topic Name " + newObject.Name + " is already taken");*/

            _context.Topics.Add(newObject);
            _context.SaveChanges();

            return _context.Topics.First(x => x.Name == newObject.Name);
        }

        public void Delete(int id)
        {
            Topic t = _context.Topics.Find(id);
            if (t != null)
            {
                _context.Topics.Remove(t);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics;
        }

        public IEnumerable<Topic> getByCourse(int courseID)
        {
            return _context.Topics.ToList().FindAll(x => x.CourseID == courseID);
        }

        public Topic GetById(int id)
        {
            return _context.Topics.Find(id);
        }

        public Topic Update(Topic updatedObject)
        {
            Topic t = _context.Topics.Find(updatedObject.ID);
            if (t == null)
                throw new AppException("Topic not found");

            /*copy properties here*/
            t.Name = updatedObject.Name;
            t.ParrentTopicID = updatedObject.ParrentTopicID;
            t.Description = updatedObject.Description;

            _context.Topics.Update(t);
            _context.SaveChanges();

            return t;
        }
    }
}
