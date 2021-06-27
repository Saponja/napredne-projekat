using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    public class NameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                throw new NullReferenceException();
            }
            if(value is string temp)
            {
                if(temp.Length >= 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
