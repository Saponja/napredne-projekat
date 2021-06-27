using napredne_projekat.Validation;
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
        [NameValidation(ErrorMessage = "First name must be at least 2 character long")]
        public string FirstName { get; set; }
        /// <summary>
        /// Prezime studenta
        /// </summary>
        [NameValidation(ErrorMessage = "Last name must be at least 2 character long")]
        public string LastName { get; set; }
        /// <summary>
        /// Broj indeksa datog studenta
        /// </summary>
        [IndexValidation(ErrorMessage ="Index format: 2021/1111")]
        public string Index { get; set; }
        /// <summary>
        /// Prosecna ocena studenta
        /// </summary>
        [GradeValidation(ErrorMessage = "Grade must be in range of [5,10]")]
        public double Grade { get; set; }
        /// <summary>
        /// Datum rodjenja studetna
        /// </summary>
        [YearOfBirthValidation(ErrorMessage = "Year of birth must be less then 2003")]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Lista predmeta koje student pohadja
        /// </summary>
        public List<Enrollment> Subjects { get; set; }
    }
}
