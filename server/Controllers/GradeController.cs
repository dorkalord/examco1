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
    [Route("/grade")]
    public class GradeController : Controller
    {
        private IGradeService _gradeService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public GradeController(
            IGradeService gradeService,
            IUserService userService,
            ITopicService topicService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _gradeService = gradeService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var grades = _gradeService.GetAll();
            var gradesDto = _mapper.Map<IList<GradeDto>>(grades);
            return Ok(gradesDto);
        }

        [HttpGet("exam/{examID}")]
        public IActionResult GetByExam(int examID)
        {
            List<Grade> grades = _gradeService.GetAll().ToList();
            var gradesDto = _mapper.Map<IList<GradeDto>>(grades.FindAll(x => x.ExamID == examID));
            return Ok(gradesDto);
        }

        [HttpGet("default")]
        public IActionResult GetDefault()
        {
            List<Grade> grades = _gradeService.GetAll().ToList();
            var gradesDto = _mapper.Map<IList<GradeDto>>(grades.FindAll(x => x.ExamID == null));
            return Ok(gradesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var grade = _gradeService.GetById(id);
            var gradeDto = _mapper.Map<GradeDto>(grade);
            return Ok(gradeDto);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]GradeDto gradeDto)
        {
            // map dto to entity and set id
            Grade c = _mapper.Map<Grade>(gradeDto);
            try
            {
                // save 
                c = _gradeService.Create(c);
                return Ok(_mapper.Map<GradeDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Upadate existing grade
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gradeDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]GradeDto gradeDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Grade>(gradeDto);
            c.ID = id;

            try
            {
                // save 
                c = _gradeService.Update(c);
                return Ok(_mapper.Map<GradeDto>(c));
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
            _gradeService.Delete(id);
            return Ok();
        }


    }
}
