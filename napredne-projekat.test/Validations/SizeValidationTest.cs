using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class SizeValidationTest
    {
        private SizeValidation sizeValidation;
        public SizeValidationTest()
        {
            sizeValidation = new SizeValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(sizeValidation.IsValid(2.12));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(23)]
        [InlineData(12)]
        public void SizeInRangeShouldBeTrue(int size)
        {
            var result = sizeValidation.IsValid(size);
            Assert.True(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(24)]
        public void SizeOutOfTheRangeShouldBeFalse(int size)
        {
            var result = sizeValidation.IsValid(size);
            Assert.False(result);
        }

    }
}
