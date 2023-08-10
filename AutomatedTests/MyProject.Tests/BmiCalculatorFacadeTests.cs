using FluentAssertions;

namespace MyProject.Tests
{
    public class BmiCalculatorFacadeTests
    {
        private const string OVERWEIGHT_SUMMARY = "You are underweight, you should put on some weight";

        [Fact]
        public void BmiCalculatorFacade_ForMetricType_GetCorrectMetricSystem()
        {
            //arrange

            var bmiCalculatorFacade = new BmiCalculatorFacade
                (UnitSystem.Metric, new BmiDeterminator());

            var weight = 50;
            var heigth = 180;

            //act

            var result = bmiCalculatorFacade.GetResult(weight, heigth);

            //assert

            //Assert.Equal(15.43, result.Bmi);
            //Assert.Equal(BmiClassification.Underweight, result.BmiClassification);
            //Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);

            result.Bmi.Should().Be(15.43);
            result.BmiClassification.Should().Be(BmiClassification.Underweight);
            result.Summary.Should().Be(OVERWEIGHT_SUMMARY);
        }
    }
}90
