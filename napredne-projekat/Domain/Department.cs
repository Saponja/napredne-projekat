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
        public string Name { get; set; }
        /// <summary>
        /// Velicina katedre, odosno broj ljudi na katedri
        /// </summary>
        public int Size { get; set; }

    }
}
