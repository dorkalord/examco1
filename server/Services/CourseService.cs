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
    public interface ICourseService: IService<Course>
    {
    }

    public class CourseService : ICourseService
    { 
        private DataContext _context;

        public CourseService(DataContext context)
        {
            _context = context;
        }

        public Course Create(Course newObject)
        {
            if (_context.Courses.Any(x => x.Code == newObject.Code ))
                throw new AppException("Course code " + newObject.Code + " is already taken");

            _context.Courses.Add(newObject);
            _context.SaveChanges();

            return _context.Courses.First(x => x.Code == newObject.Code);
        }

        public void Delete(int id)
        {
            Course c = _context.Courses.Find(id);
            if (c != null)
            {
                _context.Courses.Remove(c);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public Course Update(Course updatedObject)
        {
            Course c = _context.Courses.Find(updatedObject.ID);
            if (c == null)
                throw new AppException("Course not found");

            c.Name = updatedObject.Name;
            c.Code = updatedObject.Code;
            c.LecturerID = updatedObject.LecturerID;

            _context.Courses.Update(c);
            _context.SaveChanges();

            return c;
        }
    }
}
