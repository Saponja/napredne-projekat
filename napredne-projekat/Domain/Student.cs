using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Index { get; set; }
        public double Grade { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Enrollment> Subjects { get; set; }
    }
}
