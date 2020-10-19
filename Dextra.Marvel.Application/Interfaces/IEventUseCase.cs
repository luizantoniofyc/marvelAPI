using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces
{
    public interface IEventUseCase : IDisposable
    {
        Task<EventDataWrapper> GetListAsync(int characterId, EventInput eventInput);
    }
}
