using System.Text;

namespace MyProject.Tests
{
    public class StringBuilderTests
    {
        [Fact]
        public void StringBuilder_For2Chars_ReturnConcatenatedString()
        {
            //arrange

            var sb = new StringBuilder();

            //act

            sb.Append('A')
                .Append('B');

            //assert

            Assert.Equal("AB", sb.ToString());
        }
    }
}