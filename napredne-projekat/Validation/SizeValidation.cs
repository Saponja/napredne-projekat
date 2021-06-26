using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    public class SizeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is Int32 temp)
            {
                if(temp > 4 && temp < 24)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
