using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class BmIDeterminatorTests
    {
        [Fact]
        public void DetermineBmi_ForDmi18_GetBmiUnderWeight()
        {
            //arrange

            var bmideterminator = new BmiDeterminator();
            var bmi = 18;

            //act

            var bmiResult = bmideterminator.DetermineBmi(bmi);

            //assert

            Assert.Equal(BmiClassification.Underweight, bmiResult);
        }

        [Theory]
        [InlineData(10.0, BmiClassification.Underweight)]
        [InlineData(3.0, BmiClassification.Underweight)]
        [InlineData(15.0, BmiClassification.Underweight)]
        [InlineData(19.0, BmiClassification.Normal)]
        [InlineData(28.0, BmiClassification.Overweight)]
        [InlineData(34.0, BmiClassification.Obesity)]
        [InlineData(55.0, BmiClassification.ExtremeObesity)]
        public void DetermineBmi_ForSpecificBmi_GetCorrectBmiClassification(double bmi, BmiClassification expected)
        {
            //arrange

            var bmideterminator = new BmiDeterminator();

            //act

            var bmiResult = bmideterminator.DetermineBmi(bmi);

            //assert

            Assert.Equal(expected, bmiResult);
        }
    }
}
