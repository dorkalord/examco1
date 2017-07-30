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
    [Route("/state")]
    public class StateController : Controller
    {
        private IStateService _stateService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public StateController(
            IStateService stateService,
            IUserService userService,
            ITopicService topicService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _stateService = stateService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var states = _stateService.GetAll();
            var statesDto = _mapper.Map<IList<StateDto>>(states);
            return Ok(statesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var state = _stateService.GetById(id);
            var stateDto = _mapper.Map<StateDto>(state);
            return Ok(stateDto);
        }

        
        [HttpPost()]
        public IActionResult Create([FromBody]StateDto stateDto)
        {
            // map dto to entity and set id
            State c = _mapper.Map<State>(stateDto);
            try
            {
                // save 
                c = _stateService.Create(c);
                return Ok(_mapper.Map<StateDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]StateDto stateDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<State>(stateDto);
            c.ID = id;

            try
            {
                // save 
                c = _stateService.Update(c);
                return Ok(_mapper.Map<StateDto>(c));
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
            _stateService.Delete(id);
            return Ok();
        }
    }
}
