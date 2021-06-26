using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    /// <summary>
    /// Domenska klasa koja predstavlja predmet
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Properti koji predstavlja id predmeta
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// Properti koji predstavlja naziv predmeta
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Properti koji predstavlja koliko espb nosi predmet
        /// </summary>
        public int ESPB { get; set; }
        /// <summary>
        /// Properti koji predstavlja id katedre kojoj predmet pripada
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Katedra kojoj predmet pripada
        /// </summary>
        public Department Department { get; set; }
        /// <summary>
        /// Lista studenata koji pohadjaju ovaj predmet
        /// </summary>
        public List<Enrollment> Students { get; set; }

    }
}
