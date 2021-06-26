using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Validation
{
    public class DepartmentNameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                throw new NullReferenceException();
            }
            if(value is string temp)
            {
                if (temp.ToLower().Contains("katedra"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
