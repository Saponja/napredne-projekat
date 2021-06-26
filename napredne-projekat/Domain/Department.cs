using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    /// <summary>
    /// Domenska klasa koja predstavlja katedru
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id katedre
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// Naziv katedre
        /// </summary>
        [DepartmentNameValidation(ErrorMessage = ("Department name must contains 'katedra'"))]
        public string Name { get; set; }
        /// <summary>
        /// Velicina katedre, odosno broj ljudi na katedri
        /// </summary>
        [SizeValidation(ErrorMessage = "Size cant be less then 4 and grater then 24")]
        public int Size { get; set; }
        /// <summary>
        /// Parametrizovani konstruktor klase Department
        /// </summary>
        /// <param name="departmentId">Id katedre</param>
        /// <param name="name">Naziv katedre</param>
        /// <param name="size">Broj ljudi na katedri</param>
        

    }
}
