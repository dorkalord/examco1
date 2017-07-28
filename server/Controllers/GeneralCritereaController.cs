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
    [Route("/generalCriterea")]
    public class GeneralCritereaController : Controller
    {
        private IGeneralCritereaService _generalCritereaService;
        private IUserService _userService;
        private IAdviceService _adviceService;
        private IMapper _mapper;

        public GeneralCritereaController(
            IGeneralCritereaService generalCritereaService,
            IUserService userService,
            IAdviceService adviceService,
        IMapper mapper)
        {
            _adviceService = adviceService;
            _userService = userService;
            _generalCritereaService = generalCritereaService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var generalCritereas = _generalCritereaService.GetAll();
            var generalCritereasDto = _mapper.Map<IList<GeneralCritereaSimpleDto>>(generalCritereas);
            return Ok(generalCritereasDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var generalCriterea = _generalCritereaService.GetById(id);

            if (generalCriterea != null)
            {
                generalCriterea.Advices = _adviceService.getByCriterea(id).ToList();
            }

            var generalCritereaDto = _mapper.Map<GeneralCritereaDto>(generalCriterea);
            return Ok(generalCritereaDto);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]GeneralCritereaDto generalCritereaDto)
        {
            // map dto to entity and set id
            GeneralCriterea c = _mapper.Map<GeneralCriterea>(generalCritereaDto);
            try
            {
                // save 
                c = _generalCritereaService.Create(c);
                return Ok(_mapper.Map<GeneralCritereaDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Upadate existing generalCriterea
        /// </summary>
        /// <param name="id"></param>
        /// <param name="generalCritereaDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]GeneralCritereaDto generalCritereaDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<GeneralCriterea>(generalCritereaDto);
            c.ID = id;

            try
            {
                // save 
                c = _generalCritereaService.Update(c);
                for (int i = 0; i < generalCritereaDto.Advices.ToList().Count ; i++)
                {
                    Advice temp = _mapper.Map<Advice>(generalCritereaDto.Advices.ElementAt(i));
                    _adviceService.Update(temp);
                }


                return Ok(_mapper.Map<GeneralCritereaDto>(c));
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
            _generalCritereaService.Delete(id);
            return Ok();
        }


    }
}
