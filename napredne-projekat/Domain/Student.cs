using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    /// <summary>
    /// Domenska klasa koja predstavlja studenta
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Id studenta
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Ime studetna
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Prezime studenta
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Broj indeksa datog studenta
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// Prosecna ocena studenta
        /// </summary>
        public double Grade { get; set; }
        /// <summary>
        /// Datum rodjenja studetna
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Lista predmeta koje student pohadja
        /// </summary>
        public List<Enrollment> Subjects { get; set; }
    }
}
