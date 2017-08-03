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
    [Route("/censor")]
    public class CensorController : Controller
    {
        private ICensorService _censorService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public CensorController(
            ICensorService censorService,
            IUserService userService,
            ITopicService topicService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _censorService = censorService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var censors = _censorService.GetAll();
            var censorsDto = _mapper.Map<IList<CensorDto>>(censors);
            return Ok(censorsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var censor = _censorService.GetById(id);
            var censorDto = _mapper.Map<CensorDto>(censor);
            return Ok(censorDto);
        }

        [HttpGet("/exam/{examID}/user/{userID}")]
        public IActionResult GetExamCensor(int examID, int userID)
        {
            var censor = _censorService.GetExamCensor(examID, userID);
            var censorDto = _mapper.Map<CensorDto>(censor);
            return Ok(censorDto);
        }


        [HttpPost()]
        public IActionResult Create([FromBody]CensorDto censorDto)
        {
            // map dto to entity and set id
            Censor c = _mapper.Map<Censor>(censorDto);
            try
            {
                // save 
                c = _censorService.Create(c);
                return Ok(_mapper.Map<CensorDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("many")]
        public IActionResult CreateMany([FromBody]List<CensorDto> censorDto)
        {
            // map dto to entity and set id
            List<Censor> c = _mapper.Map<List<Censor>>(censorDto);
            try
            {
                // save 
                c = _censorService.CreateMany(c);
                return Ok(_mapper.Map<List<CensorDto>>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CensorDto censorDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Censor>(censorDto);
            c.ID = id;

            try
            {
                // save 
                c = _censorService.Update(c);
                return Ok(_mapper.Map<CensorDto>(c));
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
            _censorService.Delete(id);
            return Ok();
        }
    }
}
