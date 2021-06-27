using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class YearOfBirthValidationTest
    {
        private YearOfBirthValidation yearOfBirthValidation;
        public YearOfBirthValidationTest()
        {
            yearOfBirthValidation = new YearOfBirthValidation();
        }

        [Fact]
        public void NullDateShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => yearOfBirthValidation.IsValid(null));
        }

        [Fact]
        public void DateWithYearLessThenTwoThousendAndThreeShouldBeTrue()
        {
            DateTime date = new DateTime(2002, 12, 5);
            var result = yearOfBirthValidation.IsValid(date);
            Assert.True(result);
        }
        [Fact]
        public void DateWithYearGraterThenTwoThousendAndTwoShouldBeFalse()
        {
            DateTime date = new DateTime(2004, 12, 5);
            var result = yearOfBirthValidation.IsValid(date);
            Assert.False(result);
        }



    }
}
