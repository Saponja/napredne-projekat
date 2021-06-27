using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju ocene studenata
    /// </summary>
    public class GradeValidation : ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object value)
        {
            if(value is Int32 temp)
            {
                if(temp >= 5 && temp <= 10)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
