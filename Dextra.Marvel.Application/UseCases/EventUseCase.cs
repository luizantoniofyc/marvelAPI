using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.UseCases
{
    public class EventUseCase : IEventUseCase
    {
        private readonly IEventRepository _eventRepository;

        public EventUseCase(
            IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventDataWrapper> GetListAsync(int characterId, EventInput eventInput)
        {
            if (!eventInput.Limit.HasValue)
                throw new BusinessException(ExceptionMessages.BN004, "BN004");

            if (eventInput.Limit > 100)
                throw new BusinessException(ExceptionMessages.BN001, "BN001");

            if (eventInput.Limit < 1)
                throw new BusinessException(ExceptionMessages.BN002, "BN002");

            if (!eventInput.Offset.HasValue) { eventInput.Offset = 0; }

            return await _eventRepository.GetEventsByCharacter(characterId, eventInput);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
