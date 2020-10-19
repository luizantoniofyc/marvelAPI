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
    public class ComicUseCaseTest
    {
        private readonly IComicUseCase _comicUseCase;
        private readonly Mock<IComicRepository> _comicRepository;

        public ComicUseCaseTest()
        {
            _comicRepository = new Mock<IComicRepository>();
            _comicUseCase = new ComicUseCase(_comicRepository.Object);
        }

        [Fact]
        public async Task ComicUseCaseTest_GetListAsync_Success()
        {
            // Arrange
            var comicInput = ComicInputFaker.Create().Generate();
            var comicDataWrapper = ComicDataWrapperFaker.Create().Generate();

            // Setup
            _comicRepository
                .Setup(p => p.GetComicsByCharacter(1, comicInput))
                .Returns(Task.FromResult(comicDataWrapper));

            // Act
            var result = await _comicUseCase.GetListAsync(1, comicInput);

            //Assert
            Assert.True(result.Data.Results.Any());
        }
        
        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN001()
        {
            // Arrange
            var comicInput = ComicInputFaker.Create().Generate();
            comicInput.Limit = 200;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _comicUseCase.GetListAsync(1, comicInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN001, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN002()
        {
            // Arrange
            var comicInput = ComicInputFaker.Create().Generate();
            comicInput.Limit = 0;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _comicUseCase.GetListAsync(1, comicInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN002, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN004()
        {
            // Arrange
            var comicInput = ComicInputFaker.Create().Generate();
            comicInput.Limit = null;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _comicUseCase.GetListAsync(1, comicInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN004, exception.Message);
        }
    }
}
