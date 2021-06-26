using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Exeptions.cs
{
    public class IdException : Exception
    {
        public IdException()
        {

        }
        public IdException(string message) : base(message)
        {
            
        }
    }
}
