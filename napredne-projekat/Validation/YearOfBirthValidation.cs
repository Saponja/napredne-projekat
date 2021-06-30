using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju godine rodjenja
    /// </summary>
    public class YearOfBirthValidation : ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                throw new NullReferenceException();
            }
            if(value is DateTime date)
            {
                if(date.Year <= 2002)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
