using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Domain;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<EventDataWrapper> GetEventsByCharacter(int characterId, EventInput eventInput);
    }
}
