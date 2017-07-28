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
        }
    }
}