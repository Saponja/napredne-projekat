using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class NameValidationTest
    {
        private NameValidation nameValidation;

        public NameValidationTest()
        {
            nameValidation = new NameValidation();
        }

        [Fact]
        public void NonStringTypeShoudlBeFalse()
        {
            Assert.False(nameValidation.IsValid(123));
        }

        [Theory]
        [InlineData("Pera")]
        [InlineData("En")]
        [InlineData("Mia")]
        public void NameLongerThenOneCharacterShouldBeTrue(string name)
        {
            var result = nameValidation.IsValid(name);
            Assert.True(result);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("")]
        public void NameShorterThen2CharacterShouldBeFalse(string name)
        {
            var result = nameValidation.IsValid(name);
            Assert.False(result);
        }

        [Fact]
        public void NullNameShoudThrowNullReferenceExeption()
        {
            Assert.Throws<NullReferenceException>(() => nameValidation.IsValid(null));
        }






    }
}
