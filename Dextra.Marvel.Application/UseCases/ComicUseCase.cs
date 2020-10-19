using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.UseCases
{
    public class ComicUseCase : IComicUseCase
    {
        private readonly IComicRepository _comicRepository;

        public ComicUseCase(
            IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }

        public async Task<ComicDataWrapper> GetListAsync(int characterId, ComicInput comicInput)
        {
            if (!comicInput.Limit.HasValue)
                throw new BusinessException(ExceptionMessages.BN004, "BN004");

            if (comicInput.Limit > 100)
                throw new BusinessException(ExceptionMessages.BN001, "BN001");

            if (comicInput.Limit < 1)
                throw new BusinessException(ExceptionMessages.BN002, "BN002");

            if (!comicInput.Offset.HasValue) { comicInput.Offset = 0; }

            return await _comicRepository.GetComicsByCharacter(characterId, comicInput);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
