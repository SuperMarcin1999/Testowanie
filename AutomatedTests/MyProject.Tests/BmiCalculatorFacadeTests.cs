using FluentAssertions;
using Moq;
using Xunit.Abstractions;

namespace MyProject.Tests
{
    public class BmiCalculatorFacadeTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public BmiCalculatorFacadeTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }


        private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";
        private const string UNDERWEIGHT_SUMMARY = "You are underweight, you should put on some weight";
        private const string NORMAL_SUMMARY = "Your weight is normal, keep it up";
        private const string OBESITY_SUMMARY = "You should take care of your obesity";
        private const string EXTREMEOBESITY_SUMMARY = "Your extreme obesity might cause health problems";

        [Theory]
        [InlineData(BmiClassification.Underweight, UNDERWEIGHT_SUMMARY)]
        [InlineData(BmiClassification.Overweight, OVERWEIGHT_SUMMARY)]
        [InlineData(BmiClassification.ExtremeObesity, EXTREMEOBESITY_SUMMARY)]
        [InlineData(BmiClassification.Normal, NORMAL_SUMMARY)]
        [InlineData(BmiClassification.Obesity, OBESITY_SUMMARY)]
        public void BmiCalculatorFacade_ForMetricType_GetCorrectSummary(BmiClassification bmiClassification, string expectedResult)
        {
            //arrange
            
            var bmiDeterminatorMoq = new Mock<IBmiDeterminator>();
            bmiDeterminatorMoq
                .Setup(x => x.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);

            var bmiCalculatorFacade = 
                new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMoq.Object);

            //act

            var result = bmiCalculatorFacade.GetResult(1, 1);

            _outputHelper.WriteLine($"{result.Bmi}, {result.BmiClassification}, {result.Summary}");

            //assert

            result.Summary.Should().Be(expectedResult);
        }
    }
}
