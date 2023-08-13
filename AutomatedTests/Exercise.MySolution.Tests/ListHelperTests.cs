using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Exercise.MySolution.Tests
{
    public class ListHelperTests
    {
        [Fact]
        public void FilterOddNumber_ForOddNumbers_ReturnListWithThatNumbers()
        {
            // arrange
            var testList = new List<int>() {1, 3, 5, 7, 9};
            var expected = new List<int>() { 1, 3, 5, 7, 9 };

            // act
            var result = ListHelper.FilterOddNumber(testList);

            // assert
            result.Should().Equal(expected);
        }
        [Fact]
        public void FilterOddNumber_ForEvenNumbers_ReturnEmptyList()
        {
            // arrange
            var testList = new List<int>() { 2, 4, 6, 8, 10 };
            var expected = new List<int>();

            // act
            var result = ListHelper.FilterOddNumber(testList);

            // assert
            result.Should().Equal(expected);
        }

        [Fact]
        public void FilterOddNumber_ForMixedNumbers_ReturnOnlyOdds()
        {
            // arrange
            var testList = new List<int>() { 2, 4, 6, 8, 10, 13, 15, 16, 17 };
            var expected = new List<int>() { 13, 15, 17 };

            // act
            var result = ListHelper.FilterOddNumber(testList);

            // assert
            result.Should().Equal(expected);
        }

        [Fact]
        public void FilterOddNumber_ForMixedOrder_ReturnCorrectResult()
        {
            // arrange
            var testList = new List<int>() { 1, 25,12,55,14,99,25,42,51,99,0,0 };
            var expected = new List<int>() {1, 25, 55, 99, 25, 51, 99};

            // act
            var result = ListHelper.FilterOddNumber(testList);

            // assert
            result.Should().Equal(expected);
        }
    }
}
