using Dextra.Marvel.Domain.Entities;
using Dextra.Marvel.Infra.Data.Fakers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Seeds
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MarvelContext(serviceProvider.GetRequiredService<DbContextOptions<MarvelContext>>()))
            {
                if (context.Characters.Any())
                {
                    return;
                }

                // Add fakers to database
                context.Characters.AddRange(CharacterFaker.Create().Generate(20));
                context.Creators.AddRange(CreatorFaker.Create().Generate(30));
                context.Comics.AddRange(ComicFaker.Create().Generate(50));
                context.Events.AddRange(EventFaker.Create().Generate(100));
                context.Series.AddRange(SerieFaker.Create().Generate(150));
                context.Stories.AddRange(StoryFaker.Create().Generate(200));
                context.SaveChanges();

                // Add character comics to database
                var characterComics = new List<CharacterComic>();
                context.Characters.ToList().ForEach(character =>
                {
                    context.Comics.OrderBy(r => Guid.NewGuid()).Take(10).ToList().ForEach(comic =>
                    {
                        characterComics.Add(new CharacterComic()
                        {
                            CharacterId = character.Id,
                            ComicId = comic.Id
                        });
                    });
                });

                context.CharacterComics.AddRange(characterComics);
                context.SaveChanges();

                // Add character events to database
                var characterEvents = new List<CharacterEvent>();
                context.Characters.ToList().ForEach(character =>
                {
                    context.Events.OrderBy(r => Guid.NewGuid()).Take(7).ToList().ForEach(evnt =>
                    {
                        characterEvents.Add(new CharacterEvent()
                        {
                            CharacterId = character.Id,
                            EventId = evnt.Id
                        });
                    });
                });

                context.CharacterEvents.AddRange(characterEvents);
                context.SaveChanges();

                // Add character series to database
                var characterSeries = new List<CharacterSerie>();
                context.Characters.ToList().ForEach(character =>
                {
                    context.Series.OrderBy(r => Guid.NewGuid()).Take(15).ToList().ForEach(serie =>
                    {
                        characterSeries.Add(new CharacterSerie()
                        {
                            CharacterId = character.Id,
                            SerieId = serie.Id
                        });
                    });
                });

                context.CharacterSeries.AddRange(characterSeries);
                context.SaveChanges();

                // Add character stories to database
                var characterStories = new List<CharacterStory>();
                context.Characters.ToList().ForEach(character =>
                {
                    context.Stories.OrderBy(r => Guid.NewGuid()).Take(30).ToList().ForEach(story =>
                    {
                        characterStories.Add(new CharacterStory()
                        {
                            CharacterId = character.Id,
                            StoryId = story.Id
                        });
                    });
                });

                context.CharacterStories.AddRange(characterStories);
                context.SaveChanges();

                // Add comic events to database
                var comicEvents = new List<ComicEvent>();
                context.Comics.ToList().ForEach(comic =>
                {
                    context.Events.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(evnt =>
                    {
                        comicEvents.Add(new ComicEvent()
                        {
                            ComicId = comic.Id,
                            EventId = evnt.Id
                        });
                    });
                });

                context.ComicEvents.AddRange(comicEvents);
                context.SaveChanges();

                // Add comic creators to database
                var comicCreators = new List<ComicCreator>();
                context.Comics.ToList().ForEach(comic =>
                {
                    context.Creators.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(creator =>
                    {
                        comicCreators.Add(new ComicCreator()
                        {
                            ComicId = comic.Id,
                            CreatorId = creator.Id
                        });
                    });
                });

                context.ComicCreators.AddRange(comicCreators);
                context.SaveChanges();

                // Add comic series to database
                var comicSeries = new List<ComicSerie>();
                context.Comics.ToList().ForEach(comic =>
                {
                    context.Series.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(serie =>
                    {
                        comicSeries.Add(new ComicSerie()
                        {
                            ComicId = comic.Id,
                            SerieId = serie.Id
                        });
                    });
                });

                context.ComicSeries.AddRange(comicSeries);
                context.SaveChanges();

                // Add comic stories to database
                var comicStories = new List<ComicStory>();
                context.Comics.ToList().ForEach(comic =>
                {
                    context.Stories.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(story =>
                    {
                        comicStories.Add(new ComicStory()
                        {
                            ComicId = comic.Id,
                            StoryId = story.Id
                        });
                    });
                });

                context.ComicStories.AddRange(comicStories);
                context.SaveChanges();

                // Add event creators to database
                var eventCreators = new List<EventCreator>();
                context.Events.ToList().ForEach(evnt =>
                {
                    context.Creators.OrderBy(r => Guid.NewGuid()).Take(5).ToList().ForEach(creator =>
                    {
                        eventCreators.Add(new EventCreator()
                        {
                            EventId = evnt.Id,
                            CreatorId = creator.Id
                        });
                    });
                });

                context.EventCreators.AddRange(eventCreators);
                context.SaveChanges();

                // Add event series to database
                var eventSeries = new List<EventSerie>();
                context.Events.ToList().ForEach(evnt =>
                {
                    context.Series.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(serie =>
                    {
                        eventSeries.Add(new EventSerie()
                        {
                            EventId = evnt.Id,
                            SerieId = serie.Id
                        });
                    });
                });

                context.EventSeries.AddRange(eventSeries);
                context.SaveChanges();

                // Add event stories to database
                var eventStories = new List<EventStory>();
                context.Events.ToList().ForEach(evnt =>
                {
                    context.Stories.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(story =>
                    {
                        eventStories.Add(new EventStory()
                        {
                            EventId = evnt.Id,
                            StoryId = story.Id
                        });
                    });
                });

                context.EventStories.AddRange(eventStories);
                context.SaveChanges();

                // Add serie creators to database
                var serieCreators = new List<SerieCreator>();
                context.Series.ToList().ForEach(serie =>
                {
                    context.Creators.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(creator =>
                    {
                        serieCreators.Add(new SerieCreator()
                        {
                            SerieId = serie.Id,
                            CreatorId = creator.Id
                        });
                    });
                });

                context.SerieCreators.AddRange(serieCreators);
                context.SaveChanges();

                // Add serie stories to database
                var serieStories = new List<SerieStory>();
                context.Series.ToList().ForEach(serie =>
                {
                    context.Stories.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(story =>
                    {
                        serieStories.Add(new SerieStory()
                        {
                            SerieId = serie.Id,
                            StoryId = story.Id
                        });
                    });
                });

                context.SerieStories.AddRange(serieStories);
                context.SaveChanges();

                // Add story creators to database
                var storyCreators = new List<StoryCreator>();
                context.Stories.ToList().ForEach(story =>
                {
                    context.Creators.OrderBy(r => Guid.NewGuid()).Take(20).ToList().ForEach(creator =>
                    {
                        storyCreators.Add(new StoryCreator()
                        {
                            StoryId = story.Id,
                            CreatorId = creator.Id
                        });
                    });
                });

                context.StoryCreators.AddRange(storyCreators);
                context.SaveChanges();
            }
        }
    }
}
