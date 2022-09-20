using EgnApp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEgnApp.Validation
{
    public class EgnNumberValidatorTest
    {
        private readonly EgnNumberValidation _validation;

        public EgnNumberValidationTests() => _validation = new EgnNumberValidation();

        [Fact]
        public void IsValid_ValidEgnNumber_ReturnsTrue()
            => Assert.True(_validation.IsValid("1234543234"));

        [Theory]
        [InlineData("1234-3454565676-23")]
        [InlineData("12-3454565676-23")]
        public void IsValid_EgnNumberFirstPartWrong_ReturnsFalse(string egnNumber)
            => Assert.False(_validation.IsValid(egnNumber));

        [Theory]
        [InlineData("12334545656")]
        [InlineData("123-345456567633-23")]
        public void IsValid_EgnNumberMiddlePartWrong_ReturnsFalse(string egnNumber)
            => Assert.False(_validation.IsValid(egnNumber));

        [Theory]
        [InlineData("123-3434545656-2")]
        [InlineData("123-3454565676-233")]
        public void IsValid_EgnNumberLastPartWrong_ReturnsFalse(string accNumber)
            => Assert.False(_validation.IsValid(accNumber));

        [Theory]
        [InlineData("123-345456567633=23")]
        [InlineData("123+345456567633-23")]
        [InlineData("123+345456567633=23")]
        public void IsValid_InvalidDelimiters_ThrowsArgumentException(string egnNumber)
            => Assert.Throws<ArgumentException>(() => _validation.IsValid(egnNumber));
    }
}
