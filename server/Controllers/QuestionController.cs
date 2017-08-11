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
    [Route("/question")]
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private IUserService _userService;
        private ITopicService _topicService;
        private IArgumentService _argumentService;
        private IMapper _mapper;

        public QuestionController(
            IQuestionService questionService,
            IUserService userService,
            ITopicService topicService,
            IArgumentService argumentService,
        IMapper mapper)
        {
            _topicService = topicService;
            _userService = userService;
            _questionService = questionService;
            _mapper = mapper;
            _argumentService = argumentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var questions = _questionService.GetAll();
            var questionsDto = _mapper.Map<IList<QuestionDto>>(questions);
            return Ok(questionsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Question question = _questionService.GetById(id);
            QuestionFullDto questionDto = _mapper.Map<QuestionFullDto>(question);
            return Ok(questionDto);
        }


        [HttpPost()]
        public IActionResult Create([FromBody]QuestionDto questionDto)
        {
            // map dto to entity and set id
            Question c = _mapper.Map<Question>(questionDto);
            try
            {
                // save 
                c = _questionService.Create(c);
                return Ok(_mapper.Map<QuestionDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("many")]
        public IActionResult CreateMany([FromBody]List<QuestionFullDto> questionDtoList)
        {
            try
            {
                List<Question> newlist = new List<Question>();
                float proposedWeight = 100 / questionDtoList.Count;
                foreach (QuestionFullDto questionDto in questionDtoList)
                {
                    Question c = _mapper.Map<Question>(_mapper.Map<QuestionCreateDto>(questionDto));
                    try
                    {
                        c.ProposedWeight = proposedWeight;
                        c = _questionService.Create(c);
                        newlist.Add(c);
                    }
                    catch (AppException ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                /*List<Question> listing = new List<Question>();
                //taking care for of the nested questions
                for (int i = 0; i < questionDtoList.Count; i++)
                {
                    listing.Add(_mapper.Map<Question>(questionDtoList[i]));

                    //taking care of parend id
                    if (questionDtoList[i].ParentQuestionID != null)
                    {
                        int parentIndex = questionDtoList.FindIndex(x => x.ID == questionDtoList[i].ParentQuestionID);
                        newlist[i].ParentQuestionID = newlist[parentIndex].ID;
                        newlist[parentIndex].ChildQuestions.Add(newlist[i]);
                        listing[parentIndex].ChildQuestions.Add(_mapper.Map<Question>(questionDtoList[i]));
                        _questionService.Update(_mapper.Map<Question>(newlist[i]));
                    }

                    List<Argument> temp = _mapper.Map<List<Argument>>( questionDtoList[i].Arguments);
                    for (int j = 0; j < temp.Count(); j++)
                    {
                        if (temp[j].ParentArgumentID != null)
                        {
                            int parentIndex = temp.FindIndex(x => x.ID == temp[j].ParentArgumentID);
                            newlist[i].Arguments.ElementAt(j).ParentArgumentID = newlist[i].Arguments.ElementAt(parentIndex).ID;
                            _argumentService.Update(_mapper.Map<Argument>(newlist[i].Arguments.ElementAt(j)));
                        }
                    }
                }
                //handeling the question weight distibution
                int numberOfParentQuestions = 0;
                foreach (Question item in listing)
                {
                    foreach (Question child in item.ChildQuestions)
                    {
                        child.Max = 100 / item.ChildQuestions.Count;
                        child.ProposedWeight = 100 / item.ChildQuestions.Count;
                        _questionService.Update(child);
                    }
                    if (item.ParentQuestionID == null)
                    {
                        numberOfParentQuestions++;
                    }
                }

                foreach (Question item in listing)
                {
                    if (item.ParentQuestionID == null)
                    {
                        item.ProposedWeight = 100 / numberOfParentQuestions;
                        item.Max = 100;
                        _questionService.Update(item);
                    }
                }/**/

                return Ok(_mapper.Map<List<QuestionFullDto>>(newlist));
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]QuestionDto questionDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Question>(questionDto);
            c.ID = id;

            try
            {
                // save 
                c = _questionService.Update(c);
                return Ok(_mapper.Map<QuestionDto>(c));
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
            _questionService.Delete(id);
            return Ok();
        }
    }
}
