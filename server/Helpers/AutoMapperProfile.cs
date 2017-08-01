using AutoMapper;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();

            CreateMap<Grade, GradeDto>();
            CreateMap<GradeDto, Grade>();

            CreateMap<GeneralCriterea, GeneralCritereaDto>();
            CreateMap<GeneralCritereaDto, GeneralCriterea>();
            CreateMap<GeneralCriterea, GeneralCritereaSimpleDto>();
            CreateMap<GeneralCritereaSimpleDto, GeneralCriterea>();

            CreateMap<Advice, AdviceDto>();
            CreateMap<AdviceDto, Advice>();

            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();
            CreateMap<Exam, ExamFullDto>();
            CreateMap<ExamFullDto, Exam>();
            CreateMap<Exam, ExamListDto>();
            CreateMap<ExamListDto, Exam>();
            CreateMap<Exam, ExamCreateDto>();
            CreateMap<ExamCreateDto, Exam>();

            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();

            CreateMap<ExamCriterea, ExamCritereaDto>();
            CreateMap<ExamCritereaDto, ExamCriterea>();

            CreateMap<ArgumentCritereaDto, ArgumentCriterea>();
            CreateMap<ArgumentCriterea, ArgumentCritereaDto>();
            CreateMap<ArgumentCritereaFullDto, ArgumentCriterea>();
            CreateMap<ArgumentCriterea, ArgumentCritereaFullDto>();

            CreateMap<TagDto, Tag>();
            CreateMap<Tag, TagDto>();
            CreateMap<TagFullDto, Tag>();
            CreateMap<Tag, TagFullDto>();

            CreateMap<ArgumentDto, Argument>();
            CreateMap<Argument, ArgumentDto>();
            CreateMap<ArgumentFullDto, Argument>();
            CreateMap<Argument, ArgumentFullDto>();

            CreateMap<QuestionDto, Question>();
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionFullDto, Question>();
            CreateMap<Question, QuestionFullDto>();
        }
    }
}