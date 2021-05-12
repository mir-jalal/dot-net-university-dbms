using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityWebDBMS.Models
{
    public class CreateCourseViewData
    {
        public List<Program> Programs { get; set; }
        public Course course { get; set; }
    }
}