using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    /// <summary>
    /// Domesnka klasa koja predstavlja pohadjanja, odnosno agregaciju izmedju klasa Student i Subject
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// Id studenta koji je vezan za ovo pohadjanje
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Student koji je vezan za ovo pohadjanje
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Id premmeta koji je vezan za ovo pohadjanje
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// Predmet koji je vezan za ovo pohadjanje
        /// </summary>
        public Subject Subject { get; set; }
    }
}
