using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int ESPB { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Enrollment> Students { get; set; }

    }
}
