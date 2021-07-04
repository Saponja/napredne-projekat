using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju espb-a
    /// </summary>
    public class EspbValidation : ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object value)
        {
            if(value is Int32 temp)
            {
                if(temp >= 2 && temp <= 8)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
