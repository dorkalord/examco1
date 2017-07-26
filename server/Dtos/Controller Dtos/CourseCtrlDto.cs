using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Dtos.Controller_Dtos
{
    public class CourseCtrlDto
    {
        public int CourseID { get; set; }
        public int LecturerID { get; set; }
        public string Lecturer { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<TopicDto> Topics { get; set; }

        public CourseCtrlDto() { }
        public CourseCtrlDto(Course course, IEnumerable<TopicDto> topics, UserDto user)
        {
            this.CourseID = course.ID;
            this.Name =        course.Name;
            this.Code =        course.Code;
            this.LecturerID =  course.LecturerID;

            this.Topics = topics;

            this.Lecturer = user.Name;
        }
    }
}
