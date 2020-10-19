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
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(MarvelContext context) : base(context)
        {

        }

        public async Task<EventDataWrapper> GetEventsByCharacter(int characterId, EventInput eventInput)
        {
            var query = _context.Set<Event>().AsNoTracking().AsQueryable();

            var creatorIds = DataHelper.GetIdList(eventInput.Creators);
            var comicIds = DataHelper.GetIdList(eventInput.Comics);
            var serieIds = DataHelper.GetIdList(eventInput.Series);
            var storyIds = DataHelper.GetIdList(eventInput.Stories);

            query = query
                .Include(i => i.CharacterEvents).ThenInclude(t => t.Character)
                .Include(i => i.ComicEvents).ThenInclude(t => t.Comic)
                .Include(i => i.EventCreators).ThenInclude(t => t.Creator)
                .Include(i => i.EventSeries).ThenInclude(t => t.Serie)
                .Include(i => i.EventStories).ThenInclude(t => t.Story)
                .Include(i => i.Thumbnail)
                .Include(i => i.Urls)
                .Where(w => (w.CharacterEvents.Any(a => a.CharacterId == characterId)) &&
                    (string.IsNullOrEmpty(eventInput.Name) || w.Title.ToLowerInvariant().Contains(eventInput.Name.ToLowerInvariant())) &&
                    (string.IsNullOrEmpty(eventInput.NameStartsWith) || w.Title.ToLowerInvariant().StartsWith(eventInput.NameStartsWith.ToLowerInvariant())) &&
                    (!eventInput.ModifiedSince.HasValue || w.Modified.Date > eventInput.ModifiedSince.Value.Date) &&
                    (!creatorIds.Any() || w.EventCreators.Any(s => creatorIds.Contains(s.CreatorId))) &&
                    (!comicIds.Any() || w.ComicEvents.Any(s => comicIds.Contains(s.EventId))) &&
                    (!serieIds.Any() || w.EventSeries.Any(s => serieIds.Contains(s.SerieId))) &&
                    (!storyIds.Any() || w.EventStories.Any(s => storyIds.Contains(s.StoryId)))
                );

            switch (eventInput.OrderBy)
            {
                case Domain.Enums.EventOrderByEnum.name:
                    query = query.OrderBy(o => o.Title);
                    break;
                case Domain.Enums.EventOrderByEnum.startDate:
                    query = query.OrderBy(o => o.Start);
                    break;
                case Domain.Enums.EventOrderByEnum.modified:
                    query = query.OrderBy(o => o.Modified);
                    break;
                case Domain.Enums.EventOrderByEnum.nameDesc:
                    query = query.OrderByDescending(o => o.Title);
                    break;
                case Domain.Enums.EventOrderByEnum.startDateDesc:
                    query = query.OrderByDescending(o => o.Start);
                    break;
                case Domain.Enums.EventOrderByEnum.modifiedDesc:
                    query = query.OrderByDescending(o => o.Modified);
                    break;
                default:
                    query = query.OrderByDescending(o => o.Title);
                    break;
            }

            var result = await query.ToPagedListAsync(eventInput.Offset.Value, eventInput.Limit.Value);

            var eventDataWrapper = EventDataWrapperFaker.Create().Generate();
            eventDataWrapper.Data = new EventDataContainer()
            {
                Count = result.Count,
                Limit = result.Limit,
                Offset = result.Offset,
                Total = result.Total,
                Results = result.Results.Select(s => new EventModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    ResourceUri = s.ResourceUri,
                    Urls = s.Urls.Select(s1 => new UrlModel()
                    {
                        Type = s1.Type,
                        Url = s1.FullUrl
                    }).ToList(),
                    Modified = s.Modified,
                    Start = s.Start,
                    End = s.End,
                    Thumbnail = new ThumbnailModel()
                    {
                        Extension = s.Thumbnail.Extension,
                        Path = s.Thumbnail.Path
                    },
                    Comics = new ComicList()
                    {
                        Available = s.ComicEvents.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicEvents.Count,
                        Items = s.ComicEvents.Select(s1 => new ComicSummary()
                        {
                            Name = s1.Comic.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Stories = new StoryList()
                    {
                        Available = s.EventStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.EventStories.Count,
                        Items = s.EventStories.Select(s1 => new StorySummary()
                        {
                            Name = s1.Story.Title,
                            ResourceURI = Guid.NewGuid().ToString(),
                            Type = s1.Story.Type
                        }).ToList()
                    },
                    Series = new SerieList()
                    {
                        Available = s.EventSeries.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.EventSeries.Count,
                        Items = s.EventSeries.Select(s1 => new SerieSummary()
                        {
                            Name = s1.Serie.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Characters = new CharacterList()
                    {
                        Available = s.CharacterEvents.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterEvents.Count,
                        Items = s.CharacterEvents.Select(s1 => new CharacterSummary()
                        {
                            Name = s1.Character.Name,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Creators = new CreatorList()
                    {
                        Available = s.EventCreators.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.EventCreators.Count,
                        Items = s.EventCreators.Select(s1 => new CreatorSummary()
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
