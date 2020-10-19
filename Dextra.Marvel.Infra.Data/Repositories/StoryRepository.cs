using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models;
using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Creator;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Serie;
using Dextra.Marvel.Application.Models.Story;
using Dextra.Marvel.Domain.Entities;
using Dextra.Marvel.Infra.Data.Extensions;
using Dextra.Marvel.Infra.Data.Fakers;
using Dextra.Marvel.Infra.Data.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Infra.Data.Repositories
{
    public class StoryRepository : RepositoryBase<Story>, IStoryRepository
    {
        public StoryRepository(MarvelContext context) : base(context)
        {

        }

        public async Task<StoryDataWrapper> GetStoriesByCharacter(int characterId, StoryInput storyInput)
        {
            var query = _context.Set<Story>().AsNoTracking().AsQueryable();
            
            var comicIds = DataHelper.GetIdList(storyInput.Comics);
            var serieIds = DataHelper.GetIdList(storyInput.Series);
            var eventIds = DataHelper.GetIdList(storyInput.Events);
            var creatorIds = DataHelper.GetIdList(storyInput.Creators);

            query = query
                .Include(i => i.CharacterStories).ThenInclude(t => t.Character)
                .Include(i => i.EventStories).ThenInclude(t => t.Event)
                .Include(i => i.StoryCreators).ThenInclude(t => t.Creator)
                .Include(i => i.SerieStories).ThenInclude(t => t.Story)
                .Include(i => i.ComicStories).ThenInclude(t => t.Comic)
                .Include(i => i.Thumbnail)
                .Where(w => (w.CharacterStories.Any(a => a.CharacterId == characterId)) &&
                    (!storyInput.ModifiedSince.HasValue || w.Modified.Date > storyInput.ModifiedSince.Value.Date) &&
                    (!creatorIds.Any() || w.StoryCreators.Any(s => creatorIds.Contains(s.CreatorId))) &&
                    (!comicIds.Any() || w.ComicStories.Any(s => comicIds.Contains(s.ComicId))) &&
                    (!serieIds.Any() || w.SerieStories.Any(s => serieIds.Contains(s.SerieId))) &&
                    (!eventIds.Any() || w.EventStories.Any(s => eventIds.Contains(s.EventId)))
                );

            switch (storyInput.OrderBy)
            {
                case Domain.Enums.StoryOrderByEnum.id:
                    query = query.OrderBy(o => o.Id);
                    break;
                case Domain.Enums.StoryOrderByEnum.modified:
                    query = query.OrderBy(o => o.Modified);
                    break;
                case Domain.Enums.StoryOrderByEnum.idDesc:
                    query = query.OrderByDescending(o => o.Id);
                    break;
                case Domain.Enums.StoryOrderByEnum.modifiedDesc:
                    query = query.OrderByDescending(o => o.Modified);
                    break;
                default:
                    query = query.OrderBy(o => o.Id);
                    break;
            }

            var result = await query.ToPagedListAsync(storyInput.Offset.Value, storyInput.Limit.Value);

            var eventDataWrapper = StoryDataWrapperFaker.Create().Generate();
            eventDataWrapper.Data = new StoryDataContainer()
            {
                Count = result.Count,
                Limit = result.Limit,
                Offset = result.Offset,
                Total = result.Total,
                Results = result.Results.Select(s => new StoryModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    ResourceUri = s.ResourceUri,
                    Type = s.Type,
                    Modified = s.Modified,
                    Thumbnail = new ThumbnailModel()
                    {
                        Extension = s.Thumbnail.Extension,
                        Path = s.Thumbnail.Path
                    },
                    Comics = new ComicList()
                    {
                        Available = s.ComicStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicStories.Count,
                        Items = s.ComicStories.Select(s1 => new ComicSummary()
                        {
                            Name = s1.Comic.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Series = new SerieList()
                    {
                        Available = s.SerieStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.SerieStories.Count,
                        Items = s.SerieStories.Select(s1 => new SerieSummary()
                        {
                            Name = s1.Story.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Events = new EventList()
                    {
                        Available = s.EventStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.EventStories.Count,
                        Items = s.EventStories.Select(s1 => new EventSummary()
                        {
                            Name = s1.Event.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Characters = new CharacterList()
                    {
                        Available = s.CharacterStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterStories.Count,
                        Items = s.CharacterStories.Select(s1 => new CharacterSummary()
                        {
                            Name = s1.Character.Name,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Creators = new CreatorList()
                    {
                        Available = s.StoryCreators.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.StoryCreators.Count,
                        Items = s.StoryCreators.Select(s1 => new CreatorSummary()
                        {
                            Name = s1.Creator.Name,
                            ResourceUri = Guid.NewGuid().ToString(),
                            Role = s1.Creator.Role
                        }).ToList()
                    }
                }).ToList()
            };

            return eventDataWrapper;
        }
    }
}
