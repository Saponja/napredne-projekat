using napredne_projekat.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Validations
{
    public class IndexValidationTest
    {
        private IndexValidation indexValidation;
        public IndexValidationTest()
        {
            indexValidation = new IndexValidation();
        }

        [Theory]
        [InlineData("2017/0054")]
        [InlineData("2029/1234")]

        public void ValidIndexShouldBeTrue(string index)
        {
            var result = indexValidation.IsValid(index);
            Assert.True(result);
        }

        [Theory]
        [InlineData("111/2324")]
        [InlineData("1222/124")]
        [InlineData("1231/++/1231")]

        public void InvalidIndexShouldBeFalse(string index)
        {
            var result = indexValidation.IsValid(index);
            Assert.False(result);
        }

        [Fact]
        public void NullIndexShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => indexValidation.IsValid(null));
        }



    }
}
