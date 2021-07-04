using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Exeptions.cs
{
    /// <summary>
    /// Klasa koja nasledjuje klasu Exception, i predstavlja Exception kada se unese nevalidan Id
    /// </summary>
    public class IdException : Exception
    {
        /// <summary>
        /// Bezparmatraski konstruktor koji kreira objekat klase IdException
        /// </summary>
        public IdException()
        {

        }
        /// <summary>
        /// Parametraski konstruktor koji kreira objekat klase IdException i postavlja vrednost za message
        /// </summary>
        /// <param name="message">Poruka exceptiona kao String</param>
        public IdException(string message) : base(message)
        {
            
        }
    }
}
