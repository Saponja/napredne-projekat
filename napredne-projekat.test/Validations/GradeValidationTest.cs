using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class GradeValidationTest
    {
        private GradeValidation gradeValidation;
        public GradeValidationTest()
        {
            gradeValidation = new GradeValidation();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(8)]
        [InlineData(10)]
        public void GradeInRangeShouldBeTrue(int grade)
        {
            var result = gradeValidation.IsValid(grade);
            Assert.True(result);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(4)]
        public void GradeOutOfTheRangeShouldBeFalse(int grade)
        {
            var result = gradeValidation.IsValid(grade);
            Assert.False(result);
        }



    }
}
