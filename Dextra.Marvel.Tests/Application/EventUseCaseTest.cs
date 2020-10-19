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
    public class EventUseCaseTest
    {
        private readonly IEventUseCase _eventUseCase;
        private readonly Mock<IEventRepository> _eventRepository;

        public EventUseCaseTest()
        {
            _eventRepository = new Mock<IEventRepository>();
            _eventUseCase = new EventUseCase(_eventRepository.Object);
        }

        [Fact]
        public async Task EventUseCaseTest_GetListAsync_Success()
        {
            // Arrange
            var eventInput = EventInputFaker.Create().Generate();
            var eventDataWrapper = EventDataWrapperFaker.Create().Generate();

            // Setup
            _eventRepository
                .Setup(p => p.GetEventsByCharacter(1, eventInput))
                .Returns(Task.FromResult(eventDataWrapper));

            // Act
            var result = await _eventUseCase.GetListAsync(1, eventInput);

            //Assert
            Assert.True(result.Data.Results.Any());
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN001()
        {
            // Arrange
            var eventInput = EventInputFaker.Create().Generate();
            eventInput.Limit = 200;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _eventUseCase.GetListAsync(1, eventInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN001, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN002()
        {
            // Arrange
            var eventInput = EventInputFaker.Create().Generate();
            eventInput.Limit = 0;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _eventUseCase.GetListAsync(1, eventInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN002, exception.Message);
        }

        [Fact]
        public async Task CharacterUseCaseTest_GetListAsync_BN004()
        {
            // Arrange
            var eventInput = EventInputFaker.Create().Generate();
            eventInput.Limit = null;

            // Act
            var exception = await Assert.ThrowsAsync<BusinessException>(async () => await _eventUseCase.GetListAsync(1, eventInput));

            //Assert
            Assert.Contains(ExceptionMessages.BN004, exception.Message);
        }
    }
}
