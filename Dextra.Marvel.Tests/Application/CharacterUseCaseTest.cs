using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.UseCases;
using Dextra.Marvel.Tests.Fakers;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Dextra.Marvel.Tests.Application
{
    public class CharacterUseCaseTest
    {
        private readonly ICharacterUseCase _characterUseCase;
        private readonly Mock<ICharacterRepository> _characterRepository;

        public CharacterUseCaseTest()
        {
            _characterRepository = new Mock<ICharacterRepository>();
            _characterUseCase = new CharacterUseCase(_characterRepository.Object);
        }
        
        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_Success()
        {
            // Arrange
            var characterInput = CharacterInputFaker.Create().Generate();
            var characterDataWrapper = CharacterDataWrapperFaker.Create().Generate();

            // Setup
            _characterRepository
                .Setup(p => p.GetCharacter(characterInput))
                .Returns(Task.FromResult(characterDataWrapper));
            
            // Act
            var result = await _characterUseCase.GetListAsync(characterInput);

            //Assert
            Assert.True(result.Data.Results.Any());
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetByIdAsync_Success()
        {
            // Arrange
            var characterInput = CharacterInputFaker.Create().Generate();
            var characterDataWrapper = CharacterDataWrapperFaker.Create().Generate();
            
            // Setup
            _characterRepository
                .Setup(p => p.GetCharacter(characterInput))
                .Returns(Task.FromResult(characterDataWrapper));

            // Act
            var result = await _characterUseCase.GetByIdAsync(characterInput);

            //Assert
            Assert.True(result.Data.Results.Any());
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetByIdAsync_NotFound()
        {
            // Arrange
            var characterInput = CharacterInputFaker.Create().Generate();
            var characterDataWrapper = CharacterDataWrapperFaker.Create().Generate();
            characterDataWrapper.Data.Results.Clear();
            characterDataWrapper.Data.Count = 0;

            // Setup
            _characterRepository
                .Setup(p => p.GetCharacter(characterInput))
                .Returns(Task.FromResult(characterDataWrapper));

            // Act
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _characterUseCase.GetByIdAsync(characterInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN008, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN001()
        {
            // Arrange
            var characterInput = CharacterInputFaker.Create().Generate();
            characterInput.Limit = 200;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _characterUseCase.GetListAsync(characterInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN001, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN002()
        {
            // Arrange
            var characterInput = CharacterInputFaker.Create().Generate();
            characterInput.Limit = 0;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _characterUseCase.GetListAsync(characterInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN002, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN004()
        {
            // Arrange
            var characterInput = CharacterInputFaker.Create().Generate();
            characterInput.Limit = null;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _characterUseCase.GetListAsync(characterInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN004, exception.Message);
        }
    }
}
