using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace S1.Entities
{
    public class StudentCourse
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        public int StudentId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}