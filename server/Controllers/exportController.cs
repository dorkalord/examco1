using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("export")]

    public class ExportController : Controller
    {
        private IExamService _examService;
        private IExamCritereaService _examCritereaService;
        private IGeneralCritereaService _generalCritereaService;
        private IExamAttemptService _examAttemptService;
        private IStateService _stateService;
        private ITopicService _topicService;
        private IMapper _mapper;

        public ExportController(
            IExamService examService,
            IExamCritereaService examCritereaService,
            IGeneralCritereaService generalCritereaService,
            IExamAttemptService examAttemptService,
            IStateService stateService,
            ITopicService topicService,
        IMapper mapper)
        {
            _examCritereaService = examCritereaService;
            _examService = examService;
            _generalCritereaService = generalCritereaService;
            _examAttemptService = examAttemptService;
            _stateService = stateService;
            _topicService = topicService;
            _mapper = mapper;

        }

        [HttpGet("exam/{examID}")]
        public FileStreamResult GetExam(int examID)
        {
            ExamExport data = new ExamExport();
            try
            {
                Exam exam = _examService.GetByIdForExport(examID);
                data = exam.export();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
            }


            MemoryStream stream = new MemoryStream();

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Exam");
                worksheet.Cells[1, 1].LoadFromCollection(data.QuestionArguments, true, OfficeOpenXml.Table.TableStyles.Medium1);

                worksheet = package.Workbook.Worksheets.Add("ExamCritereas");
                worksheet.Cells[1, 1].LoadFromCollection(data.QuestionArguments, true, OfficeOpenXml.Table.TableStyles.Medium1);

                worksheet = package.Workbook.Worksheets.Add("ArgumentCriterea");
                worksheet.Cells[1, 1].LoadFromCollection(data.ArgumentCritereas, true, OfficeOpenXml.Table.TableStyles.Medium1);
                //package.Save(); //Save the workbook.
                stream = new MemoryStream(package.GetAsByteArray());
            }

            return new FileStreamResult(stream, new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                FileDownloadName = "exam " + examID + ".xlsx"
            };
        }

        [HttpGet("examAttempts/{examID}")]
        public FileStreamResult GetAttempt(int examID)
        {
            ExamAttemptExport data = new ExamAttemptExport();
            List<ExamAttempt> attempts = new List<ExamAttempt>();
            try
            {
                attempts = _examAttemptService.getAllForExport(examID).ToList();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
            }

            foreach (ExamAttempt item in attempts)
            {
                var temp = item.export();
                data.AttemptMistakes.AddRange(temp.AttemptMistakes);
                data.AttemptCritereas.AddRange(temp.AttemptCritereas);
            }

            MemoryStream stream = new MemoryStream();

            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("AttemptCriterea");
                worksheet.Cells[1, 1].LoadFromCollection(data.AttemptCritereas, true, OfficeOpenXml.Table.TableStyles.Medium1);

                worksheet = package.Workbook.Worksheets.Add("AttemptMistakes");
                worksheet.Cells[1, 1].LoadFromCollection(data.AttemptMistakes, true, OfficeOpenXml.Table.TableStyles.Medium1);

                stream = new MemoryStream(package.GetAsByteArray());
            }

            return new FileStreamResult(stream, new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                FileDownloadName = "exam cenorsihp " + examID + ".xlsx"
            };
        }
    }
}
