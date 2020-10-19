using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces
{
    public interface ICharacterUseCase : IDisposable
    {
        Task<CharacterDataWrapper> GetListAsync(CharacterInput characterInput);

        Task<CharacterDataWrapper> GetByIdAsync(CharacterInput characterInput);
    }
}
