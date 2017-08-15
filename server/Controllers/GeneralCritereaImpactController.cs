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
    [Route("/generalCritereaImpact")]
    public class GeneralCritereaImpactController : Controller
    {
        private IGeneralCritereaImpactService _generalCritereaImpactService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IArgumentService _argumentService;
        private IMapper _mapper;

        public GeneralCritereaImpactController(
            IGeneralCritereaImpactService generalCritereaImpactService,
            IUserService userService,
            ITopicService topicService,
            IArgumentService argumentService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _generalCritereaImpactService = generalCritereaImpactService;
            _mapper = mapper;
            _argumentService = argumentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var generalCritereaImpacts = _generalCritereaImpactService.GetAll();
            var generalCritereaImpactsDto = _mapper.Map<IList<GeneralCritereaImpactDto>>(generalCritereaImpacts);
            return Ok(generalCritereaImpactsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneralCritereaImpact generalCritereaImpact = _generalCritereaImpactService.GetById(id);
            GeneralCritereaImpactDto generalCritereaImpactDto = _mapper.Map<GeneralCritereaImpactDto>(generalCritereaImpact);
            return Ok(generalCritereaImpactDto);
        }


        [HttpPost()]
        public IActionResult Create([FromBody]GeneralCritereaImpactDto generalCritereaImpactDto)
        {
            // map dto to entity and set id
            GeneralCritereaImpact c = _mapper.Map<GeneralCritereaImpact>(generalCritereaImpactDto);
            try
            {
                // save 
                c = _generalCritereaImpactService.Create(c);
                return Ok(_mapper.Map<GeneralCritereaImpactDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("many")]
        public IActionResult CreateMany([FromBody]List<GeneralCritereaImpactCreateDto> generalCritereaImpactDtoList)
        {
            try
            {
                List<GeneralCritereaImpact> newlist = new List<GeneralCritereaImpact>();
                foreach (GeneralCritereaImpactCreateDto generalCritereaImpactDto in generalCritereaImpactDtoList)
                {
                    GeneralCritereaImpact c = _mapper.Map<GeneralCritereaImpact>(generalCritereaImpactDto);
                    try
                    {
                        c = _generalCritereaImpactService.Create(c);
                        newlist.Add(c);
                    }
                    catch (AppException ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Ok(_mapper.Map<List<GeneralCritereaImpactDto>>(newlist));
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("many")]
        public IActionResult UpdateMany([FromBody]List<GeneralCritereaImpactDto> generalCritereaImpactDtoList)
        {
            try
            {
                List<GeneralCritereaImpact> newlist = new List<GeneralCritereaImpact>();
                foreach (GeneralCritereaImpactDto generalCritereaImpactDto in generalCritereaImpactDtoList)
                {
                    GeneralCritereaImpact c = _mapper.Map<GeneralCritereaImpact>(generalCritereaImpactDto);
                    try
                    {
                        c = _generalCritereaImpactService.Update(c);
                        newlist.Add(c);
                    }
                    catch (AppException ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Ok(_mapper.Map<List<GeneralCritereaImpactDto>>(newlist));
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]GeneralCritereaImpactDto generalCritereaImpactDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<GeneralCritereaImpact>(generalCritereaImpactDto);
            c.ID = id;

            try
            {
                // save 
                c = _generalCritereaImpactService.Update(c);
                return Ok(_mapper.Map<GeneralCritereaImpactDto>(c));
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
            _generalCritereaImpactService.Delete(id);
            return Ok();
        }
    }
}
