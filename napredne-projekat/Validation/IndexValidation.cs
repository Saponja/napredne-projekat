using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju formata indexa
    /// </summary>
    public class IndexValidation : ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                throw new NullReferenceException();
            }
            Regex regex = new Regex(@"[0-9]{4}[/]{1}[0-9]{4}");
            if(value is string temp)
            {
                var match = regex.Match(temp);
                if (match.Success)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
