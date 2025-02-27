﻿using System.Collections;

namespace Exercise.MySolution.Tests.Data
{
    public class ValidatorDataTests : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
