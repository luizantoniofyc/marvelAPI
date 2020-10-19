using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.UseCases;
using Dextra.Marvel.Tests.Fakers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dextra.Marvel.Tests.Application
{
    public class SerieUseCaseTest
    {
        private readonly ISerieUseCase _serieUseCase;
        private readonly Mock<ISerieRepository> _serieRepository;

        public SerieUseCaseTest()
        {
            _serieRepository = new Mock<ISerieRepository>();
            _serieUseCase = new SerieUseCase(_serieRepository.Object);
        }

        [Fact]
        public async Task SerieUseCaseTest_GetListAsync_Success()
        {
            // Arrange
            var serieInput = SerieInputFaker.Create().Generate();
            var serieDataWrapper = SerieDataWrapperFaker.Create().Generate();

            // Setup
            _serieRepository
                .Setup(p => p.GetSeriesByCharacter(1, serieInput))
                .Returns(Task.FromResult(serieDataWrapper));

            // Act
            var result = await _serieUseCase.GetListAsync(1, serieInput);

            //Assert
            Assert.True(result.Data.Results.Any());
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN001()
        {
            // Arrange
            var serieInput = SerieInputFaker.Create().Generate();
            serieInput.Limit = 200;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _serieUseCase.GetListAsync(1, serieInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN001, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN002()
        {
            // Arrange
            var serieInput = SerieInputFaker.Create().Generate();
            serieInput.Limit = 0;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _serieUseCase.GetListAsync(1, serieInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN002, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN004()
        {
            // Arrange
            var serieInput = SerieInputFaker.Create().Generate();
            serieInput.Limit = null;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _serieUseCase.GetListAsync(1, serieInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN004, exception.Message);
        }
    }
}
