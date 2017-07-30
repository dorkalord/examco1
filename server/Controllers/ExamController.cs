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
    [Route("/exam")]
    public class ExamController : Controller
    {
        private IExamService _examService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public ExamController(
            IExamService examService,
            IUserService userService,
            ITopicService topicService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _examService = examService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exams = _examService.GetAll();
            var examsDto = _mapper.Map<IList<ExamListDto>>(exams);
            return Ok(examsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var exam = _examService.GetById(id);
            var examDto = _mapper.Map<ExamFullDto>(exam);
            return Ok(examDto);
        }

        [HttpGet("author/{id}")]
        public IActionResult GetByAuthor(int id)
        {
            var exam = _examService.GetById(id);
            var examDto = _mapper.Map<ExamListDto>(exam);
            return Ok(examDto);
        }

        [HttpGet("censor/{id}")]
        public IActionResult GetByCensor(int id)
        {
            var exam = _examService.GetById(id);
            var examDto = _mapper.Map<ExamListDto>(exam);
            return Ok(examDto);
        }

        [HttpGet("student/{id}")]
        public IActionResult GetByStudent(int id)
        {
            var exam = _examService.GetById(id);
            var examDto = _mapper.Map<ExamListDto>(exam);
            return Ok(examDto);
        }




        [HttpPost()]
        public IActionResult Create([FromBody]ExamDto examDto)
        {
            // map dto to entity and set id
            Exam c = _mapper.Map<Exam>(examDto);
            try
            {
                // save 
                c = _examService.Create(c);
                return Ok(_mapper.Map<ExamDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ExamDto examDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Exam>(examDto);
            c.ID = id;

            try
            {
                // save 
                c = _examService.Update(c);
                return Ok(_mapper.Map<ExamDto>(c));
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
            _examService.Delete(id);
            return Ok();
        }
    }
}
