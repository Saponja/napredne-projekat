using napredne_projekat.Validation;
using Newtonsoft.Json;
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
        [NameValidation(ErrorMessage = "Name must be at least 3 char long")]
        public string Name { get; set; }
        /// <summary>
        /// Properti koji predstavlja koliko espb nosi predmet
        /// </summary>
        [EspbValidation(ErrorMessage = "Espb must be in range of [2,8]")]
        public int ESPB { get; set; }
        /// <summary>
        /// Properti koji predstavlja id katedre kojoj predmet pripada
        /// </summary>
        [JsonIgnore]
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
