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
    public class StoryUseCaseTest
    {
        private readonly IStoryUseCase _storyUseCase;
        private readonly Mock<IStoryRepository> _storyRepository;
        
        public StoryUseCaseTest()
        {
            _storyRepository = new Mock<IStoryRepository>();
            _storyUseCase = new StoryUseCase(_storyRepository.Object);
        }

        [Fact]
        public async Task StoryUseCaseTest_GetListAsync_Success()
        {
            // Arrange
            var storyInput = StoryInputFaker.Create().Generate();
            var storyDataWrapper = StoryDataWrapperFaker.Create().Generate();

            // Setup
            _storyRepository
                .Setup(p => p.GetStoriesByCharacter(1, storyInput))
                .Returns(Task.FromResult(storyDataWrapper));

            // Act
            var result = await _storyUseCase.GetListAsync(1, storyInput);

            //Assert
            Assert.True(result.Data.Results.Any());
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN001()
        {
            // Arrange
            var storyInput = StoryInputFaker.Create().Generate();
            storyInput.Limit = 200;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _storyUseCase.GetListAsync(1, storyInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN001, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN002()
        {
            // Arrange
            var storyInput = StoryInputFaker.Create().Generate();
            storyInput.Limit = 0;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _storyUseCase.GetListAsync(1, storyInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN002, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN004()
        {
            // Arrange
            var storyInput = StoryInputFaker.Create().Generate();
            storyInput.Limit = null;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _storyUseCase.GetListAsync(1, storyInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN004, exception.Message);
        }
    }
}
