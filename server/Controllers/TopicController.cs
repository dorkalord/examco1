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
    [Route("/topic")]
    public class TopicController : Controller
    {
        private ITopicService _topicService;
        private IMapper _mapper;

        public TopicController(
            ITopicService topicService,
            IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var topics = _topicService.GetAll();
            var topicsDto = _mapper.Map<IList<TopicDto>>(topics);
            return Ok(topicsDto);
        }

        /// <summary>
        /// Gets all the topics from a particular Course
        /// </summary>
        /// <param name="id">Course ID</param>
        /// <returns></returns>
        [HttpGet("course/{id}")]
        public IActionResult GetByCourse(int id)
        {
            List<Topic> topics = _topicService.GetAll().ToList();
            var topicsDto = _mapper.Map<IList<TopicDto>>(topics.FindAll(x => x.CourseID == id));
            return Ok(topicsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var topic = _topicService.GetById(id);
            var topicDto = _mapper.Map<TopicDto>(topic);
            return Ok(topicDto);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]TopicDto topicDto)
        {
            // map dto to entity and set id
            Topic c = _mapper.Map<Topic>(topicDto);

            try
            {
                // save 
                c = _topicService.Create(c);
                return Ok(_mapper.Map<TopicDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("many")]
        public IActionResult CrateMany([FromBody]List<TopicDto> topicsDto)
        {
            try
            {
                List<TopicDto> newlist = new List<TopicDto>();
                foreach (TopicDto topicDto in topicsDto)
                {
                    // map dto to entity and set id
                    var c = new Topic{ Name = topicDto.Name, Description = topicDto.Description, CourseID = topicDto.CourseID };
                    
                    try
                    {
                        // save 
                        c = _topicService.Create(c);

                        newlist.Add(_mapper.Map<TopicDto>(c));
                    }
                    catch (AppException ex)
                    {
                        // return error message if there was an exception
                        return BadRequest(ex.Message);
                    }
                }

                for (int i = 0; i < topicsDto.Count; i++)
                {
                    if (topicsDto[i].ParrentTopicID != null)
                    {
                        int parentIndex = topicsDto.FindIndex(x => x.ID == topicsDto[i].ParrentTopicID);
                        newlist[i].ParrentTopicID = newlist[parentIndex].ID;
                        _topicService.Update(_mapper.Map<Topic>(newlist[i]));
                    }
                }
                
                return Ok(newlist);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public IActionResult UpdateMany([FromBody]IEnumerable<TopicDto> topicsDto)
        {
            try
            {
                List<TopicDto> updatedlist = new List<TopicDto>();
                foreach (TopicDto topicDto in topicsDto)
                {
                    // map dto to entity and set id
                    var c = _mapper.Map<Topic>(topicDto);

                    try
                    {
                        // save 
                        c = _topicService.Update(c);
                        
                        updatedlist.Add(_mapper.Map<TopicDto>(c));
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
        public IActionResult Update(int id, [FromBody]TopicDto topicDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Topic>(topicDto);
            c.ID = id;

            try
            {
                // save 
                c = _topicService.Update(c);
                return Ok(_mapper.Map<TopicDto>(c));
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
            _topicService.Delete(id);
            return Ok();
        }
    }
}
