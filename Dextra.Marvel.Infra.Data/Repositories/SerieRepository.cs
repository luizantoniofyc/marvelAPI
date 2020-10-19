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
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        public SerieRepository(MarvelContext context) : base(context)
        {

        }

        public async Task<SerieDataWrapper> GetSeriesByCharacter(int characterId, SerieInput serieInput)
        {
            var query = _context.Set<Serie>().AsNoTracking().AsQueryable();

            var creatorIds = DataHelper.GetIdList(serieInput.Creators);
            var comicIds = DataHelper.GetIdList(serieInput.Comics);
            var eventIds = DataHelper.GetIdList(serieInput.Events);
            var storyIds = DataHelper.GetIdList(serieInput.Stories);

            query = query
                .Include(i => i.CharacterSeries).ThenInclude(t => t.Character)
                .Include(i => i.EventSeries).ThenInclude(t => t.Event)
                .Include(i => i.SerieCreators).ThenInclude(t => t.Creator)
                .Include(i => i.ComicSeries).ThenInclude(t => t.Comic)
                .Include(i => i.SerieStories).ThenInclude(t => t.Story)
                .Include(i => i.Thumbnail)
                .Include(i => i.Urls)
                .Where(w => (w.CharacterSeries.Any(a => a.CharacterId == characterId)) &&
                    (string.IsNullOrEmpty(serieInput.Title) || w.Title.ToLowerInvariant().Contains(serieInput.Title.ToLowerInvariant())) &&
                    (string.IsNullOrEmpty(serieInput.TitleStartsWith) || w.Title.ToLowerInvariant().StartsWith(serieInput.TitleStartsWith.ToLowerInvariant())) &&
                    (!serieInput.StartYear.HasValue || w.StartYear == serieInput.StartYear.Value) &&
                    (!serieInput.ModifiedSince.HasValue || w.Modified.Date > serieInput.ModifiedSince.Value.Date) &&
                    (!comicIds.Any() || w.ComicSeries.Any(s => comicIds.Contains(s.ComicId))) &&
                    (!storyIds.Any() || w.SerieStories.Any(s => storyIds.Contains(s.StoryId))) &&
                    (!eventIds.Any() || w.EventSeries.Any(s => eventIds.Contains(s.EventId))) &&
                    (!creatorIds.Any() || w.SerieCreators.Any(s => creatorIds.Contains(s.CreatorId)))
                );

            switch (serieInput.OrderBy)
            {
                case Domain.Enums.SerieOrderByEnum.title:
                    query = query.OrderBy(o => o.Title);
                    break;
                case Domain.Enums.SerieOrderByEnum.modified:
                    query = query.OrderBy(o => o.Modified);
                    break;
                case Domain.Enums.SerieOrderByEnum.startDate:
                    query = query.OrderBy(o => o.StartYear);
                    break;
                case Domain.Enums.SerieOrderByEnum.titleDesc:
                    query = query.OrderByDescending(o => o.Title);
                    break;
                case Domain.Enums.SerieOrderByEnum.modifiedDesc:
                    query = query.OrderByDescending(o => o.Modified);
                    break;
                case Domain.Enums.SerieOrderByEnum.startDateDesc:
                    query = query.OrderByDescending(o => o.StartYear);
                    break;
                default:
                    query = query.OrderBy(o => o.Title);
                    break;
            }

            var result = await query.ToPagedListAsync(serieInput.Offset.Value, serieInput.Limit.Value);

            var eventDataWrapper = SerieDataWrapperFaker.Create().Generate();
            eventDataWrapper.Data = new SerieDataContainer()
            {
                Count = result.Count,
                Limit = result.Limit,
                Offset = result.Offset,
                Total = result.Total,
                Results = result.Results.Select(s => new SerieModel()
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
                    StartYear = s.StartYear,
                    EndYear = s.EndYear,
                    Rating = s.Rating,
                    Modified = s.Modified,
                    Thumbnail = new ThumbnailModel()
                    {
                        Extension = s.Thumbnail.Extension,
                        Path = s.Thumbnail.Path
                    },
                    Comics = new ComicList()
                    {
                        Available = s.ComicSeries.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicSeries.Count,
                        Items = s.ComicSeries.Select(s1 => new ComicSummary()
                        {
                            Name = s1.Comic.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Stories = new StoryList()
                    {
                        Available = s.SerieStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.SerieStories.Count,
                        Items = s.SerieStories.Select(s1 => new StorySummary()
                        {
                            Name = s1.Story.Title,
                            ResourceURI = Guid.NewGuid().ToString(),
                            Type = s1.Story.Type
                        }).ToList()
                    },
                    Events = new EventList()
                    {
                        Available = s.EventSeries.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.EventSeries.Count,
                        Items = s.EventSeries.Select(s1 => new EventSummary()
                        {
                            Name = s1.Event.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Characters = new CharacterList()
                    {
                        Available = s.CharacterSeries.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterSeries.Count,
                        Items = s.CharacterSeries.Select(s1 => new CharacterSummary()
                        {
                            Name = s1.Character.Name,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Creators = new CreatorList()
                    {
                        Available = s.SerieCreators.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.SerieCreators.Count,
                        Items = s.SerieCreators.Select(s1 => new CreatorSummary()
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
