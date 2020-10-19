using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.UseCases
{
    public class StoryUseCase : IStoryUseCase
    {
        private readonly IStoryRepository _storyRepository;

        public StoryUseCase(
            IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDataWrapper> GetListAsync(int characterId, StoryInput storyInput)
        {
            if (!storyInput.Limit.HasValue)
                throw new BusinessException(ExceptionMessages.BN004, "BN004");

            if (storyInput.Limit > 100)
                throw new BusinessException(ExceptionMessages.BN001, "BN001");

            if (storyInput.Limit < 1)
                throw new BusinessException(ExceptionMessages.BN002, "BN002");

            if (!storyInput.Offset.HasValue) { storyInput.Offset = 0; }

            return await _storyRepository.GetStoriesByCharacter(characterId, storyInput);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
