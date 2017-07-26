using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Dtos;
using AutoMapper;
using WebApi.Helpers;
using WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using WebApi.Dtos.Controller_Dtos;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("/course")]
    public class CoursesControler : Controller
    {
        private ICourseService _courseService;
        private IUserService _UserService;
        private IMapper _mapper;

        public CoursesControler(
            ICourseService courseService,
            IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _courseService.GetAll();
            var coursesDto = _mapper.Map<IList<CourseDto>>(courses);
            return Ok(coursesDto);
        }

        [HttpGet("lecturer/{userID}")]
        public IActionResult GetByLecturer(int userID)
        {
            List<Course> courses =  _courseService.GetAll().ToList();
            var coursesDto = _mapper.Map<IList<CourseDto>>(courses.FindAll(x => x.LecturerID == userID));
            return Ok(coursesDto);
        }

        [AllowAnonymous]
        [HttpGet("detail/{id}")]
        public IActionResult GetById(int id)
        {
            Course course = _courseService.GetById(id);
            CourseCtrlDto res = new 
                CourseCtrlDto(course, _mapper.Map<IEnumerable<TopicDto>>(course.Topics), _mapper.Map<UserDto>(course.Lecturer));
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CourseDto courseDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Course>(courseDto);
            c.ID = id;

            try
            {
                // save 
                _courseService.Update(c);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.Delete(id);
            return Ok();
        }
    }
}
