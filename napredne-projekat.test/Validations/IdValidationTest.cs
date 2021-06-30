using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class IdValidationTest
    {
        private readonly IdValidation idValidation;

        public IdValidationTest()
        {
            idValidation = new IdValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(idValidation.IsValid(2.12));
        }

        [Fact]
        public void IdGraterThenZeroShouldBeValid()
        {
            var result = idValidation.IsValid(8);
            Assert.True(result);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-123)]
        [InlineData(0)]
        public void IdLessThenZeroShouldBeInvalid(int id)
        {
            var result = idValidation.IsValid(id);
            Assert.False(result);
        }

        [Fact]
        public void IdNullShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => idValidation.IsValid(null));
        }

    }
}
