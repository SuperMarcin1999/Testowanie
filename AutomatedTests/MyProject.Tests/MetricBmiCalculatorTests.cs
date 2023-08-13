using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Tests.Data;

namespace MyProject.Tests
{
    public class MetricBmiCalculatorTests
    {
        public static IEnumerable<object[]> GetSampleData()
        {
            yield return new object[] {80, 180, 24.69};
            yield return new object[] {75, 180, 23.15};
            yield return new object[] {55, 190, 15.24};
        }
        


        [Theory]
        [MemberData(nameof(GetSampleData))]
        public void CalculateBmi_ForCorrectWeightAndHeight_GetBmi(double weight, double height, double expected)
        {
            //arrange

            var calculator = new MetricBmiCalculator();
            
            //act

            var result = calculator.CalculateBmi(weight, height);

            //assert

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(MetricBmiCalculatorTestData))]
        public void CalculateBmi_ForIncorrectWeightOrHeight_ThrowArgumentException(double weight, double height)
        {
            //arrange

            var calculator = new MetricBmiCalculator();

            //act

            Action action = () => calculator.CalculateBmi(weight, height);

            //assert

            Assert.Throws<ArgumentException>(action);
        }
    }
}
