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

            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();
        }
    }
}