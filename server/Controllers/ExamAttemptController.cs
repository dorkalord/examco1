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
using System;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route("/examAttempt")]
    public class ExamAttemptController : Controller
    {
        private IExamAttemptService _examAttemptService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public ExamAttemptController(
            IExamAttemptService examAttemptService,
            IUserService userService,
            ITopicService topicService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _examAttemptService = examAttemptService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var examAttempts = _examAttemptService.GetAll();
            var examAttemptsDto = _mapper.Map<IList<ExamAttemptDto>>(examAttempts);
            return Ok(examAttemptsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var examAttempt = _examAttemptService.GetById(id);
            var examAttemptDto = _mapper.Map<ExamAttemptFullDto>(examAttempt);
            return Ok(examAttemptDto);
        }

        [HttpGet("censor/{censorID}/exam/{examID}")]
        public IActionResult GetByCensorExam(int censorID, int examID)
        {
            var examAttempt = _examAttemptService.getAllForCensorExam(examID, censorID);
            var examAttemptDto = _mapper.Map<List<ExamAttemptFullDto>>(examAttempt.ToList());
            return Ok(examAttemptDto);
        }


        [HttpPost()]
        public IActionResult Create([FromBody]ExamAttemptCreateDto examAttemptDto)
        {
            // map dto to entity and set id
            ExamAttempt c = _mapper.Map<ExamAttempt>(examAttemptDto);
            try
            {
                // save 
                c.CensorshipDate = DateTime.Now;
                c = _examAttemptService.Create(c);
                return Ok(_mapper.Map<ExamAttemptDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ExamAttemptDto examAttemptDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<ExamAttempt>(examAttemptDto);
            c.ID = id;

            try
            {
                // save 
                c = _examAttemptService.Update(c);
                return Ok(_mapper.Map<ExamAttemptDto>(c));
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
            _examAttemptService.Delete(id);
            return Ok();
        }
    }
}
