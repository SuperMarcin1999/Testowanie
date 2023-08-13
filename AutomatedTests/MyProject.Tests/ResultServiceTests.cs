using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MyProject.Service;

namespace MyProject.Tests
{
    public class ResultServiceTests
    {
        [Fact]
        public void SetRecentOverweightResult_ForOverweightResult_SetRecent()
        {
            //arrange

            var resultService = new ResultService(new ResultRepository());
            var bmiResult = new BmiResult()
            {
                BmiClassification = BmiClassification.Overweight
            };

            //act

            resultService.SetRecentOverweightResult(bmiResult);

            //assert
            
            resultService.RecentOverweightResult.Should().Be(bmiResult);
        }

        [Fact]
        public void SetRecentOverweightResult_ForNotOverweightResult_RecentNotSet()
        {
            // arrange

            var resultService = new ResultService(new ResultRepository());
            var bmiResult = new BmiResult()
            {
                BmiClassification = BmiClassification.ExtremeObesity
            };

            // act

            resultService.SetRecentOverweightResult(bmiResult);

            // assert

            resultService.RecentOverweightResult.Should().NotBe(bmiResult);
            resultService.RecentOverweightResult.Should().Be(null);
        }

        //public async Task SaveUnderweightResultAsync(BmiResult result)
        //{
        //    if (result.BmiClassification == BmiClassification.Underweight)
        //    {
        //        await _resultRepository.SaveResultAsync(result);
        //    }
        //}

        [Fact]
        public async Task SaveUnderweightResultAsync_ForUnderweight_SaveAsync()
        {
            // arrange
            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);
            var bmiResult = new BmiResult() { BmiClassification = BmiClassification.Underweight };

            // act
            await resultService.SaveUnderweightResultAsync(bmiResult);

            // assert
            repoMock.Verify(x => x.SaveResultAsync(bmiResult), Times.Once);
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForNotUnderweight_NotSave()
        {
            // arrange
            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);
            var bmiResult = new BmiResult() { BmiClassification = BmiClassification.ExtremeObesity};

            // act
            await resultService.SaveUnderweightResultAsync(bmiResult);

            // assert
            repoMock.Verify(x => x.SaveResultAsync(bmiResult), Times.Never);
        }
    }
}
