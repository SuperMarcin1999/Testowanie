using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class MetricBmiCalculatorTests
    {
        [Theory]
        [InlineData(80, 180, 24.69)]
        [InlineData(75, 180, 23.15)]
        [InlineData(55, 190, 15.24)]
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
        [InlineData(0, 180)]
        [InlineData(75, 0)]
        [InlineData(-8, 190)]
        [InlineData(8, -190)]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
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
