using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces
{
    public interface IStoryUseCase : IDisposable
    {
        Task<StoryDataWrapper> GetListAsync(int characterId, StoryInput storyInput);
    }
}
