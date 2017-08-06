using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.Dtos;
using AutoMapper;
using WebApi.Helpers;
using WebApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route("/mistake")]
    public class MistakeController : Controller
    {
        private IMistakeService _mistakeService;
        private IMapper _mapper;

        public MistakeController(
            IMistakeService mistakeService,
            IMapper mapper)
        {
            _mistakeService = mistakeService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var mistakes = _mistakeService.GetAll();
            var mistakesDto = _mapper.Map<IList<MistakeDto>>(mistakes);
            return Ok(mistakesDto);
        }

        /// <summary>
        /// Gets all the mistakes from a particular Course
        /// </summary>
        /// <param name="id">Anwser ID</param>
        /// <returns></returns>
        [HttpGet("course/{id}")]
        public IActionResult GetByAnwser(int id)
        {
            List<Mistake> mistakes = _mistakeService.getByAnwser(id).ToList() ;
            var mistakesDto = _mapper.Map<IList<MistakeDto>>(mistakes);
            return Ok(mistakesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var mistake = _mistakeService.GetById(id);
            var mistakeDto = _mapper.Map<MistakeDto>(mistake);
            return Ok(mistakeDto);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]MistakeCreateDto mistakeDto)
        {
            // map dto to entity and set id
            Mistake c = _mapper.Map<Mistake>(mistakeDto);

            try
            {
                // save 
                c = _mistakeService.Create(c);
                return Ok(_mapper.Map<MistakeDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }


        [HttpPut()]
        public IActionResult UpdateMany([FromBody]IEnumerable<MistakeDto> mistakesDto)
        {
            try
            {
                List<MistakeDto> updatedlist = new List<MistakeDto>();
                foreach (MistakeDto mistakeDto in mistakesDto)
                {
                    // map dto to entity and set id
                    var c = _mapper.Map<Mistake>(mistakeDto);

                    try
                    {
                        // save 
                        c = _mistakeService.Update(c);

                        updatedlist.Add(_mapper.Map<MistakeDto>(c));
                    }
                    catch (AppException ex)
                    {
                        // return error message if there was an exception
                        return BadRequest(ex.Message);
                    }
                }
                return Ok(updatedlist);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]MistakeDto mistakeDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Mistake>(mistakeDto);
            c.ID = id;

            try
            {
                // save 
                c = _mistakeService.Update(c);
                return Ok(_mapper.Map<MistakeDto>(c));
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
            _mistakeService.Delete(id);
            return Ok();
        }
    }
}
