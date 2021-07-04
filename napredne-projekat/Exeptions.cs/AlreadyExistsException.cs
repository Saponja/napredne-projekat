using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Exeptions.cs
{
    /// <summary>
    /// Klasa koja nasledjuje klasu Exception i predstavlja Exception kada neki objekat vec postoji
    /// </summary>
    public class AlreadyExistsException : Exception
    {
        /// <summary>
        /// Bezparmatraski konstruktor koji kreira objekat klase AlreadyExistsException
        /// </summary>
        public AlreadyExistsException()
        {

        }
    }
}
