using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class DepartmentNameValidationTest
    {
        private DepartmentNameValidation nameValidation;
        public DepartmentNameValidationTest()
        {
            nameValidation = new DepartmentNameValidation();
        }

        [Fact]
        public void NullDepNameShouldThrowNullReferenceExpetion()
        {
            Assert.Throws<NullReferenceException>(() => nameValidation.IsValid(null));
        }

        [Theory]
        [InlineData("Katedra za IS")]
        [InlineData("Katedra za AI")]
        public void DepNameThatContainsKatedraShouldBeTrue(string name)
        {
            var result = nameValidation.IsValid(name);
            Assert.True(result);
        }

        [Theory]
        [InlineData("Kat za IS")]
        [InlineData("Ai")]
        public void DepNameThatNotContainsKatedraShouldBeFalse(string name)
        {
            var result = nameValidation.IsValid(name);
            Assert.False(result);
        }

    }
}
