using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.UseCases
{
    public class CharacterUseCase : ICharacterUseCase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterUseCase(
            ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<CharacterDataWrapper> GetListAsync(CharacterInput characterInput)
        {
            if (!characterInput.Limit.HasValue)
                throw new BusinessException(ExceptionMessages.BN004, "BN004");

            if (characterInput.Limit > 100)
                throw new BusinessException(ExceptionMessages.BN001, "BN001");

            if (characterInput.Limit < 1)
                throw new BusinessException(ExceptionMessages.BN002, "BN002");

            if (!characterInput.Offset.HasValue) { characterInput.Offset = 0; }

            return await _characterRepository.GetCharacter(characterInput);
        }

        public async Task<CharacterDataWrapper> GetByIdAsync(CharacterInput characterInput)
        {
            var result = await _characterRepository.GetCharacter(characterInput);

            if (result.Data.Count < 1)
                throw new NotFoundException(ExceptionMessages.BN008);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
