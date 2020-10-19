using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.Models;
using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Serie;
using Dextra.Marvel.Application.Models.Story;
using Dextra.Marvel.Domain;
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
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(MarvelContext context) : base(context)
        {

        }

        public async Task<CharacterDataWrapper> GetCharacter(CharacterInput characterInput)
        {
            var query = _context.Set<Character>().AsNoTracking().AsQueryable();

            query = query
                .Include(i => i.CharacterComics).ThenInclude(t => t.Comic)
                .Include(i => i.CharacterEvents).ThenInclude(t => t.Event)
                .Include(i => i.CharacterSeries).ThenInclude(t => t.Serie)
                .Include(i => i.CharacterStories).ThenInclude(t => t.Story)
                .Include(i => i.Urls)
                .Include(i => i.Thumbnail);

            if (characterInput.CharacterId.HasValue)
            {
                query = query.Where(w => w.Id == characterInput.CharacterId.Value);
            }
            else
            {
                var comicIds = DataHelper.GetIdList(characterInput.Comics);
                var eventIds = DataHelper.GetIdList(characterInput.Events);
                var serieIds = DataHelper.GetIdList(characterInput.Series);
                var storyIds = DataHelper.GetIdList(characterInput.Stories);

                query = query
                    .Where(w =>
                        (string.IsNullOrEmpty(characterInput.Name) || w.Name.ToLowerInvariant().Contains(characterInput.Name.ToLowerInvariant())) &&
                        (string.IsNullOrEmpty(characterInput.NameStartsWith) || w.Name.ToLowerInvariant().StartsWith(characterInput.NameStartsWith.ToLowerInvariant())) &&
                        (!characterInput.ModifiedSince.HasValue || w.Modified.Date > characterInput.ModifiedSince.Value.Date) &&
                        (!comicIds.Any() || w.CharacterComics.Any(s => comicIds.Contains(s.ComicId))) &&
                        (!eventIds.Any() || w.CharacterEvents.Any(s => eventIds.Contains(s.EventId))) &&
                        (!serieIds.Any() || w.CharacterSeries.Any(s => serieIds.Contains(s.SerieId))) &&
                        (!storyIds.Any() || w.CharacterStories.Any(s => storyIds.Contains(s.StoryId)))
                    );

                switch (characterInput.OrderBy)
                {
                    case Domain.Enums.CharacterOrderByEnum.Name:
                        query = query.OrderBy(o => o.Name);
                        break;
                    case Domain.Enums.CharacterOrderByEnum.Modified:
                        query = query.OrderBy(o => o.Modified);
                        break;
                    case Domain.Enums.CharacterOrderByEnum.NameDesc:
                        query = query.OrderByDescending(o => o.Name);
                        break;
                    case Domain.Enums.CharacterOrderByEnum.ModifiedDesc:
                        query = query.OrderByDescending(o => o.Modified);
                        break;
                    default:
                        query = query.OrderBy(o => o.Name);
                        break;
                }
            }
            
            var result = await query.ToPagedListAsync(characterInput.Offset.Value, characterInput.Limit.Value);

            var characterDataWrapper = CharacterDataWrapperFaker.Create().Generate();
            characterDataWrapper.Data = new CharacterDataContainer()
            {
                Count = result.Count,
                Limit = result.Limit,
                Offset = result.Offset,
                Total = result.Total,
                Results = result.Results.Select(s => new CharacterModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Modified = s.Modified,
                    ResourceURI = s.ResourceUri,
                    Thumbnail = new ThumbnailModel()
                    {
                        Extension = s.Thumbnail.Extension,
                        Path = s.Thumbnail.Path
                    },
                    Urls = s.Urls.Select(s1 => new UrlModel()
                    {
                        Type = s1.Type,
                        Url = s1.FullUrl
                    }).ToList(),
                    Comics = new ComicList()
                    {
                        Available = s.CharacterComics.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterComics.Count,
                        Items = s.CharacterComics.Select(s2 => new ComicSummary()
                        {
                            Name = s2.Comic.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Events = new EventList()
                    {
                        Available = s.CharacterComics.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterComics.Count,
                        Items = s.CharacterEvents.Select(s2 => new EventSummary()
                        {
                            Name = s2.Event.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Series = new SerieList()
                    {
                        Available = s.CharacterSeries.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterSeries.Count,
                        Items = s.CharacterSeries.Select(s2 => new SerieSummary()
                        {
                            Name = s2.Serie.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Stories = new StoryList()
                    {
                        Available = s.CharacterStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterStories.Count,
                        Items = s.CharacterStories.Select(s2 => new StorySummary()
                        {
                            Name = s2.Story.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    }
                }).ToList()
            };

            return characterDataWrapper;
        }
    }
}
