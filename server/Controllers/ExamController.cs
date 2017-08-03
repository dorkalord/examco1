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
    [Route("/exam")]
    public class ExamController : Controller
    {
        private IExamService _examService;
        private IExamCritereaService _examCritereaService;
        private IGeneralCritereaService _generalCritereaService;
        private ICourseService _courseService;
        private IStateService _stateService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public ExamController(
            IExamService examService,
            IExamCritereaService examCritereaService,
            IGeneralCritereaService generalCritereaService,
            ICourseService courseService,
            IStateService stateService,
            ITopicService topicService,
        IMapper mapper)
        {
            _examCritereaService = examCritereaService;
            _examService = examService;
            _generalCritereaService = generalCritereaService;
            _courseService = courseService;
            _stateService = stateService;
            _topicService = topicService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exams = _examService.GetAll();
            var examsDto = _mapper.Map<IList<ExamListDto>>(exams);
            return Ok(examsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)

        {
            Exam exam = _examService.GetById(id);
            exam.Course.Topics = _topicService.getByCourse(exam.Course.ID).ToList();
            var examDto = _mapper.Map<ExamFullDto>(exam);
            return Ok(examDto);
        }

        [HttpGet("forCensoring/{id}")]
        public IActionResult GetForCensoring(int id)
        {
            Exam exam = _examService.GetByIdForCensoring(id);
            var examDto = _mapper.Map<ExamFullDto>(exam);
            return Ok(examDto);
        }

        [HttpGet("author/{id}")]
        public IActionResult GetByAuthor(int id)
        {
            List<Exam> exams = _examService.getByAuthor(id).ToList();
            List<ExamListDto> examDto = _mapper.Map<List<ExamListDto>>(exams);
            return Ok(examDto);
        }

        [HttpGet("censor/{id}")]
        public IActionResult GetByCensor(int id)
        {
            List<Exam> exams = _examService.GetByCensor(id).ToList();
            List<ExamListDto> examDto = _mapper.Map<List<ExamListDto>>(exams);
            return Ok(examDto);
        }

        [HttpGet("student/{id}")]
        public IActionResult GetByStudent(int id)
        {
            var exam = _examService.GetById(id);
            var examDto = _mapper.Map<ExamListDto>(exam);
            return Ok(examDto);
        }

        [HttpGet("upadatestate/{examID}/{stateID}")]
        public IActionResult UpdateState(int examID, int stateID)
        {
            try
            {
                var exam = _examService.updateStatus(examID, stateID);
                var examDto = _mapper.Map<ExamListDto>(exam);
                return Ok(examDto);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost()]
        public IActionResult Create([FromBody]ExamCreateDto examDto)
        {
            // map dto to entity and set id
            Exam c = _mapper.Map<Exam>(examDto);
            try
            {
                c.ExamCriterea = null;
                // save 
                c = _examService.Create(c);
                return Ok(_mapper.Map<ExamDto>(c));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criterea/{id}")]
        public IActionResult CreateExamCriterea(int id, [FromBody]List<ExamCritereaDto> examCriterea)
        {
            try
            {
                foreach (ExamCritereaDto item in examCriterea)
                {
                    ExamCriterea temp = _mapper.Map<ExamCriterea>(item);
                    temp.ExamID = id;
                    
                    if (item.GeneralCritereaID == null)
                    {
                        GeneralCriterea tempcriterea = new GeneralCriterea();
                        tempcriterea.Name = temp.Name;
                        tempcriterea.Advices = temp.Advices;

                        tempcriterea = _generalCritereaService.Create(tempcriterea);
                        temp.GeneralCritereaID = tempcriterea.ID;
                    }

                    _examCritereaService.Create(temp);
                }

                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ExamDto examDto)
        {
            // map dto to entity and set id
            var c = _mapper.Map<Exam>(examDto);
            c.ID = id;

            try
            {
                // save 
                c = _examService.Update(c);
                return Ok(_mapper.Map<ExamDto>(c));
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
            _examService.Delete(id);
            return Ok();
        }
    }
}
