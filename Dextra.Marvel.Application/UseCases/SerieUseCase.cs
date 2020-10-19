using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Serie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.UseCases
{
    public class SerieUseCase : ISerieUseCase
    {
        private readonly ISerieRepository _serieRepository;

        public SerieUseCase(
            ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task<SerieDataWrapper> GetListAsync(int characterId, SerieInput serieInput)
        {
            if (!serieInput.Limit.HasValue)
                throw new BusinessException(ExceptionMessages.BN004, "BN004");

            if (serieInput.Limit > 100)
                throw new BusinessException(ExceptionMessages.BN001, "BN001");

            if (serieInput.Limit < 1)
                throw new BusinessException(ExceptionMessages.BN002, "BN002");

            if (!serieInput.Offset.HasValue) { serieInput.Offset = 0; }

            return await _serieRepository.GetSeriesByCharacter(characterId, serieInput);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
