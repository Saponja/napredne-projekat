using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju Id-a
    /// </summary>
    public class IdValidation : ValidationAttribute
    {
        ///<inheritdoc/>
        ///<exception cref="System.NullReferenceException" />
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                throw new NullReferenceException();
            }
            if(value is Int32 temp)
            {
                if(temp > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
