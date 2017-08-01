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
    [Route("/argument")]
    public class ArgumentController : Controller
    {
        private IArgumentService _argumentService;
        private IMapper _mapper;

        public ArgumentController(
            IArgumentService argumentService,
            IMapper mapper)
        {
            _argumentService = argumentService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var arguments = _argumentService.GetAll();
            var argumentsDto = _mapper.Map<IList<ArgumentDto>>(arguments);
            return Ok(argumentsDto);
        }

        /// <summary>
        /// Gets all the arguments from a particular question
        /// </summary>
        /// <param name="id">Course ID</param>
        /// <returns></returns>
        [HttpGet("question/{id}")]
        public IActionResult GetByCourse(int id)
        {
            List<Argument> arguments = _argumentService.GetAll().ToList();
            var argumentsDto = _mapper.Map<IList<ArgumentDto>>(arguments.FindAll(x => x.QuestionID == id));
            return Ok(argumentsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var argument = _argumentService.GetById(id);
            var argumentDto = _mapper.Map<ArgumentDto>(argument);
            return Ok(argumentDto);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]ArgumentDto argumentDto)
        {
            // map dto to entity and set id
            Argument c = _mapper.Map<Argument>(argumentDto);

            try
            {
                // save 
                c = _argumentService.Create(c);
                return Ok(_mapper.Map<ArgumentDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("many")]
        public IActionResult CrateMany([FromBody]List<ArgumentDto> argumentsDto)
        {
            /*try
            {
                List<ArgumentDto> newlist = new List<ArgumentDto>();
                foreach (ArgumentDto argumentDto in argumentsDto)
                {
                    // map dto to entity and set id
                    var c = new Argument { Name = argumentDto.Name, Description = argumentDto.Description, CourseID = argumentDto.CourseID };

                    try
                    {
                        // save 
                        c = _argumentService.Create(c);

                        newlist.Add(_mapper.Map<ArgumentDto>(c));
                    }
                    catch (AppException ex)
                    {
                        // return error message if there was an exception
                        return BadRequest(ex.Message);
                    }
                }

                for (int i = 0; i < argumentsDto.Count; i++)
                {
                    if (argumentsDto[i].ParrentArgumentID != null)
                    {
                        int parentIndex = argumentsDto.FindIndex(x => x.ID == argumentsDto[i].ID);
                        newlist[i].ParrentArgumentID = newlist[parentIndex].ID;
                        _argumentService.Update(_mapper.Map<Argument>(newlist[i]));
                    }
                }

                return Ok(newlist);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }*/
            throw new System.Exception("not implemented");
        }

        [HttpPut()]
        public IActionResult UpdateMany([FromBody]IEnumerable<ArgumentDto> argumentsDto)
        {
            try
            {
                List<ArgumentDto> updatedlist = new List<ArgumentDto>();
                foreach (ArgumentDto argumentDto in argumentsDto)
                {
                    // map dto to entity and set id
                    var c = _mapper.Map<Argument>(argumentDto);

                    try
                    {
                        // save 
                        c = _argumentService.Update(c);

                        updatedlist.Add(_mapper.Map<ArgumentDto>(c));
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
        public IActionResult Update(int id, [FromBody]ArgumentDto argumentDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Argument>(argumentDto);
            c.ID = id;

            try
            {
                // save 
                c = _argumentService.Update(c);
                return Ok(_mapper.Map<ArgumentDto>(c));
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
            _argumentService.Delete(id);
            return Ok();
        }
    }
}
