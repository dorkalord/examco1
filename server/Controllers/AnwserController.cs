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
    [Route("/anwser")]
    public class AnwserController : Controller
    {
        private IAnwserService _anwserService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IExamAttemptService _examAttemptService;
        private IMapper _mapper;

        public AnwserController(
            IAnwserService anwserService,
            IUserService userService,
            ITopicService topicService,
            IExamAttemptService examAttemptService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _anwserService = anwserService;
            _mapper = mapper;
            _examAttemptService = examAttemptService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var anwsers = _anwserService.GetAll();
            var anwsersDto = _mapper.Map<IList<AnwserDto>>(anwsers);
            return Ok(anwsersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var anwser = _anwserService.GetById(id);
            var anwserDto = _mapper.Map<AnwserDto>(anwser);
            return Ok(anwserDto);
        }


        [HttpPost()]
        public IActionResult Create([FromBody]AnwserDto anwserDto)
        {
            // map dto to entity and set id
            Anwser c = _mapper.Map<Anwser>(anwserDto);
            try
            {
                // save 
                c = _anwserService.Create(c);
                return Ok(_mapper.Map<AnwserDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]AnwserDto anwserDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Anwser>(anwserDto);
            c.ID = id;

            try
            {
                // save 
                c = _anwserService.Update(c);
                _examAttemptService.recalculateSimple(c.ExamAttemptID);
                return Ok(_mapper.Map<AnwserDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/{completion}")]
        public IActionResult UpdateCompletion(int id, string completion, [FromBody]AnwserDto anwserDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Anwser>(anwserDto);
            c.ID = id;

            try
            {
                c = _anwserService.UpdateCompletion(c, completion);
                return Ok(_mapper.Map<AnwserDto>(c));
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
            _anwserService.Delete(id);
            return Ok();
        }
    }
}
