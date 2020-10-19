using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Story;
using Dextra.Marvel.Domain;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces.Repository
{
    public interface IStoryRepository : IRepository<Story>
    {
        Task<StoryDataWrapper> GetStoriesByCharacter(int characterId, StoryInput storyInput);
    }
}
