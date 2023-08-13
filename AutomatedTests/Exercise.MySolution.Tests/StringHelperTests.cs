using FluentAssertions;

namespace Exercise.MySolution.Tests
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData("abc", "abc")]
        [InlineData("Kot lubi psy", "psy lubi Kot")]
        [InlineData("koko jumbo", "jumbo koko")]
        public void ReverseWord_ForInput_GiveCorrectResult(string word, string expected)
        {
            // arrange && act
            var result = StringHelper.ReverseWords(word);

            // assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("abc", false)]
        [InlineData("natan", true)]
        [InlineData("natan oho natan", true)]
        public void IsPalindrome_ForInput_GetCorrectResult(string word, bool expected)
        {
            // arrange & act
            var result = StringHelper.IsPalindrome(word);

            // assert
            result.Should().Be(expected);
        }
    }
}