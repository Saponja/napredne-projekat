using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class EspbValidationTest
    {
        EspbValidation espbValidation;

        public EspbValidationTest()
        {
            espbValidation = new EspbValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(espbValidation.IsValid(2.12));
        }

        [Theory]
        [InlineData(8)]
        [InlineData(2)]
        [InlineData(4)]
        public void ValidEspbShouldBeTrue(int espb)
        {
            Assert.True(espbValidation.IsValid(espb));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(1)]
        public void ValidEspbShouldBeFalse(int espb)
        {
            Assert.False(espbValidation.IsValid(espb));
        }

    }
}
