using System.Collections.Generic;

namespace WebApi.Dtos
{
    public class CourseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int LecturerID { get; set; }

        public UserDto Lecturer { get; set; }
        public IEnumerable<TopicDto> Topics { get; set; }
        
    }
}
