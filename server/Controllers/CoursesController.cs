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
    //[Authorize]
    [Route("/course")]
    public class CoursesController : Controller
    {
        private ICourseService _courseService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public CoursesController(
            ICourseService courseService,
            IUserService userService,
            ITopicService topicService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseService.GetById(id);
            if (course != null && course.Lecturer == null)
            {
                course.Lecturer = _userService.GetById(course.LecturerID);
                course.Topics = _topicService.getByCourse(course.ID).ToList();
            }
            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]CourseDto courseDto)
        {
            // map dto to entity and set id
            Course c = _mapper.Map<Course>(courseDto);
            c.Lecturer = null;
            try
            {
                // save 
                c = _courseService.Create(c);
                return Ok(_mapper.Map<CourseDto>(c) );
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Upadate existing course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CourseDto courseDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Course>(courseDto);
            c.ID = id;

            try
            {
                // save 
                c = _courseService.Update(c);
                return Ok(_mapper.Map<CourseDto>(c));
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
