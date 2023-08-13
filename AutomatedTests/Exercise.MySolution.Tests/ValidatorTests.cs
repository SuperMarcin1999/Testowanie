using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.MySolution.Tests.Data;
using FluentAssertions;

namespace Exercise.MySolution.Tests
{
    public class ValidatorTests
    {
        public static IEnumerable<object[]> GetDateRanges()
        {
            yield return new object[]
            {
                new List<DateRange>()
                {
                    new DateRange(new DateTime(2012, 11, 12), new DateTime(2013, 11, 12)),
                    new DateRange(new DateTime(2016, 1, 22), new DateTime(2018, 11, 1)),
                    new DateRange(new DateTime(2018, 11, 12), new DateTime(2019, 11, 2)),
                    new DateRange(new DateTime(2021, 9, 12), new DateTime(2022, 11, 12)),
                },
            };
            yield return new object[]
            {
                new List<DateRange>()
                {
                    new DateRange(new DateTime(12, 11, 12), new DateTime(2013, 11, 12)),
                    new DateRange(new DateTime(2016, 1, 22), new DateTime(2018, 11, 1)),
                    new DateRange(new DateTime(2018, 11, 12), new DateTime(2019, 11, 2)),
                    new DateRange(new DateTime(2021, 9, 12), new DateTime(2022, 11, 12)),
                }
            };
            yield return new object[]
            {
                new List<DateRange>()
                {
                    new DateRange(new DateTime(1112, 11, 12), new DateTime(2013, 11, 12)),
                    new DateRange(new DateTime(2016, 1, 22), new DateTime(2018, 11, 1)),
                    new DateRange(new DateTime(2018, 11, 12), new DateTime(2019, 11, 2)),
                    new DateRange(new DateTime(2021, 9, 12), new DateTime(2022, 11, 12)),
                }
            };
        }
        
        /* Metoda z MemberData */
        [Theory]
        [MemberData(nameof(GetDateRanges))]
        public void ValidateOverlapping_ForNotOverlapping_ReturnTrue(IEnumerable<DateRange> dateRanges)
        {
            // arrange
            var validator = new Validator();
            var input = new DateRange(new DateTime(2018, 11, 2), new DateTime(2018, 11, 10));

            // act
            var result = validator.ValidateOverlapping(dateRanges.ToList(), input);

            // assert
            result.Should().Be(true);
        }

        /* Metoda z MemberClass */
        [Theory]
        [ClassData(typeof(ValidatorDataTests))]
        public void ValidateOverlapping_ForOverlapping_ReturnFalse(IEnumerable<DateRange> dateRanges)
        {
            // arrange
            var validator = new Validator();
            var input = new DateRange(new DateTime(2018, 1, 2), new DateTime(2018, 11, 10));

            // act
            var result = validator.ValidateOverlapping(dateRanges.ToList(), input);

            // assert
            result.Should().Be(false);
        }
    }
}
