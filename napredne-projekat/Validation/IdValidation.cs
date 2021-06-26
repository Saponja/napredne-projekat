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
        /// <summary>
        /// Metoda koja proverava da li prosledjena vrednost zadovoljava uslove
        /// </summary>
        /// <param name="value"></param>
        /// <returns><list type="bullet">
        /// <item>true - ako zadovoljava uslove</item>
        /// <item>false - ako ne zadovoljava uslove</item>
        /// </list></returns>
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
