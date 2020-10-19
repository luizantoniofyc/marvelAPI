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
    public class ComicRepository : RepositoryBase<Comic>, IComicRepository
    {
        public ComicRepository(MarvelContext context) : base(context)
        {

        }

        public async Task<ComicDataWrapper> GetComicsByCharacter(int characterId, ComicInput comicInput)
        {
            var query = _context.Set<Comic>().AsNoTracking().AsQueryable();

            var creatorIds = DataHelper.GetIdList(comicInput.Creators);
            var eventIds = DataHelper.GetIdList(comicInput.Events);
            var serieIds = DataHelper.GetIdList(comicInput.Series);
            var storyIds = DataHelper.GetIdList(comicInput.Stories);

            query = query
                .Include(i => i.CharacterComics).ThenInclude(t => t.Character)
                .Include(i => i.ComicCreators).ThenInclude(t => t.Creator)
                .Include(i => i.ComicEvents).ThenInclude(t => t.Event)
                .Include(i => i.ComicSeries).ThenInclude(t => t.Serie)
                .Include(i => i.ComicStories).ThenInclude(t => t.Story)
                .Include(i => i.Urls)
                .Include(i => i.Thumbnail)
                .Include(i => i.TextObjects)
                .Include(i => i.Dates)
                .Include(i => i.Prices)
                .Include(i => i.Images)
                .Where(w => (w.CharacterComics.Any(a => a.CharacterId == characterId)) &&
                    //(string.IsNullOrEmpty(comicInput.Format.ToString()) || w.Format.ToLowerInvariant() == comicInput.Format.ToString().ToLowerInvariant()) &&
                    (!comicInput.ModifiedSince.HasValue || w.Modified.Date > comicInput.ModifiedSince.Value.Date) &&
                    (string.IsNullOrEmpty(comicInput.Title) || w.Title.ToLowerInvariant().Contains(comicInput.Title.ToLowerInvariant())) &&
                    (string.IsNullOrEmpty(comicInput.TitleStartsWith) || w.Title.ToLowerInvariant().StartsWith(comicInput.TitleStartsWith.ToLowerInvariant())) &&
                    (!comicInput.IssueNumber.HasValue || w.IssueNumber == comicInput.IssueNumber.Value) &&
                    (string.IsNullOrEmpty(comicInput.DiamondCode) || w.DiamondCode.ToLowerInvariant().Contains(comicInput.DiamondCode.ToLowerInvariant())) &&
                    (!comicInput.DigitalId.HasValue || w.DigitalId == comicInput.DigitalId.Value) &&
                    (string.IsNullOrEmpty(comicInput.Upc) || w.Upc.ToLowerInvariant().Contains(comicInput.Upc.ToLowerInvariant())) &&
                    (string.IsNullOrEmpty(comicInput.Isbn) || w.Isbn.ToLowerInvariant().Contains(comicInput.Isbn.ToLowerInvariant())) &&
                    (string.IsNullOrEmpty(comicInput.Ean) || w.Ean.ToLowerInvariant().Contains(comicInput.Ean.ToLowerInvariant())) &&
                    (string.IsNullOrEmpty(comicInput.Issn) || w.Issn.ToLowerInvariant().Contains(comicInput.Issn.ToLowerInvariant())) &&
                    (!creatorIds.Any() || w.ComicCreators.Any(s => creatorIds.Contains(s.ComicId))) &&
                    (!eventIds.Any() || w.ComicEvents.Any(s => eventIds.Contains(s.EventId))) &&
                    (!serieIds.Any() || w.ComicSeries.Any(s => serieIds.Contains(s.SerieId))) &&
                    (!storyIds.Any() || w.ComicStories.Any(s => storyIds.Contains(s.StoryId)))
                );

            switch (comicInput.OrderBy)
            {
                case Domain.Enums.ComicOrderByEnum.title:
                    query = query.OrderBy(o => o.Title);
                    break;
                case Domain.Enums.ComicOrderByEnum.issueNumber:
                    query = query.OrderBy(o => o.IssueNumber);
                    break;
                case Domain.Enums.ComicOrderByEnum.modified:
                    query = query.OrderBy(o => o.Modified);
                    break;
                case Domain.Enums.ComicOrderByEnum.titleDesc:
                    query = query.OrderByDescending(o => o.Title);
                    break;
                case Domain.Enums.ComicOrderByEnum.issueNumberDesc:
                    query = query.OrderByDescending(o => o.IssueNumber);
                    break;
                case Domain.Enums.ComicOrderByEnum.modifiedDesc:
                    query = query.OrderByDescending(o => o.Modified);
                    break;
                default:
                    query = query.OrderBy(o => o.Title);
                    break;
            }

            var result = await query.ToPagedListAsync(comicInput.Offset.Value, comicInput.Limit.Value);

            var comicDataWrapper = ComicDataWrapperFaker.Create().Generate();
            comicDataWrapper.Data = new ComicDataContainer()
            {
                Count = result.Count,
                Limit = result.Limit,
                Offset = result.Offset,
                Total = result.Total,
                Results = result.Results.Select(s => new ComicModel()
                {
                    Id = s.Id,
                    DigitalId = s.DigitalId,
                    Title = s.Title,
                    IssueNumber = s.IssueNumber,
                    VariantDescription = s.VariantDescription,
                    Description = s.Description,
                    Modified = s.Modified,
                    Isbn = s.Isbn,
                    Upc = s.Upc,
                    DiamondCode = s.DiamondCode,
                    Ean = s.Ean,
                    Issn = s.Issn,
                    Format = s.Format,
                    PageCount = s.PageCount,
                    TextObjects = s.TextObjects.Select(s1 => new TextObjectModel()
                    {
                        Language = s1.Language,
                        Text = s1.Text,
                        Type = s1.Type
                    }).ToList(),
                    ResourceUri = s.ResourceUri,
                    Urls = s.Urls.Select(s1 => new UrlModel()
                    {
                        Type = s1.Type,
                        Url = s1.FullUrl
                    }).ToList(),
                    Series = new SerieList()
                    {
                        Available = s.ComicSeries.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicSeries.Count,
                        Items = s.ComicSeries.Select(s1 => new SerieSummary()
                        {
                            Name = s1.Serie.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Dates = s.Dates.Select(s1 => new ComicDateModel()
                    {
                        Date = s1.Date,
                        Type = s1.Type
                    }).ToList(),
                    Prices = s.Prices.Select(s1 => new ComicPriceModel()
                    {
                        Price = s1.Price,
                        Type = s1.Type
                    }).ToList(),
                    Thumbnail = new ThumbnailModel()
                    {
                        Extension = s.Thumbnail.Extension,
                        Path = s.Thumbnail.Path
                    },
                    Images = s.Images.Select(s1 => new ImageModel()
                    {
                        Extension = s1.Extension,
                        Path = s1.Path
                    }).ToList(),
                    Creators = new CreatorList()
                    {
                        Available = s.ComicCreators.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicCreators.Count,
                        Items = s.ComicCreators.Select(s1 => new CreatorSummary()
                        {
                            Name = s1.Creator.Name,
                            ResourceUri = Guid.NewGuid().ToString(),
                            Role = s1.Creator.Role
                        }).ToList()
                    },
                    Characters = new CharacterList()
                    {
                        Available = s.CharacterComics.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.CharacterComics.Count,
                        Items = s.CharacterComics.Select(s1 => new CharacterSummary()
                        {
                            Name = s1.Character.Name,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                    Stories = new StoryList()
                    {
                        Available = s.ComicStories.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicStories.Count,
                        Items = s.ComicStories.Select(s1 => new StorySummary()
                        {
                            Name = s1.Story.Title,
                            ResourceURI = Guid.NewGuid().ToString(),
                            Type = s1.Story.Type
                        }).ToList()
                    },
                    Events = new EventList()
                    {
                        Available = s.ComicEvents.Count,
                        CollectionURI = Guid.NewGuid().ToString(),
                        Returned = s.ComicEvents.Count,
                        Items = s.ComicEvents.Select(s1 => new EventSummary()
                        {
                            Name = s1.Event.Title,
                            ResourceURI = Guid.NewGuid().ToString()
                        }).ToList()
                    },
                }).ToList()
            };

            return comicDataWrapper;
        }
    }
}
