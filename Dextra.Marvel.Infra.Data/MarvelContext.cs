using Dextra.Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data
{
    public class MarvelContext : DbContext
    {
        public MarvelContext(DbContextOptions<MarvelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [ Key Auto Increment ]

            modelBuilder.Entity<Character>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comic>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<ComicDate>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<ComicPrice>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Event>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Serie>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Story>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Image>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Url>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Thumbnail>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region [ Many-To-Many Relationships ]

            modelBuilder.Entity<CharacterComic>()
                .HasKey(bc => new { bc.CharacterId, bc.ComicId });
            modelBuilder.Entity<CharacterComic>()
                .HasOne(bc => bc.Character)
                .WithMany(b => b.CharacterComics)
                .HasForeignKey(bc => bc.CharacterId);
            modelBuilder.Entity<CharacterComic>()
                .HasOne(bc => bc.Comic)
                .WithMany(c => c.CharacterComics)
                .HasForeignKey(bc => bc.ComicId);

            modelBuilder.Entity<CharacterEvent>()
                .HasKey(bc => new { bc.CharacterId, bc.EventId });
            modelBuilder.Entity<CharacterEvent>()
                .HasOne(bc => bc.Character)
                .WithMany(b => b.CharacterEvents)
                .HasForeignKey(bc => bc.CharacterId);
            modelBuilder.Entity<CharacterEvent>()
                .HasOne(bc => bc.Event)
                .WithMany(c => c.CharacterEvents)
                .HasForeignKey(bc => bc.EventId);

            modelBuilder.Entity<CharacterSerie>()
                .HasKey(bc => new { bc.CharacterId, bc.SerieId });
            modelBuilder.Entity<CharacterSerie>()
                .HasOne(bc => bc.Character)
                .WithMany(b => b.CharacterSeries)
                .HasForeignKey(bc => bc.CharacterId);
            modelBuilder.Entity<CharacterSerie>()
                .HasOne(bc => bc.Serie)
                .WithMany(c => c.CharacterSeries)
                .HasForeignKey(bc => bc.SerieId);

            modelBuilder.Entity<CharacterStory>()
                .HasKey(bc => new { bc.CharacterId, bc.StoryId });
            modelBuilder.Entity<CharacterStory>()
                .HasOne(bc => bc.Character)
                .WithMany(b => b.CharacterStories)
                .HasForeignKey(bc => bc.CharacterId);
            modelBuilder.Entity<CharacterStory>()
                .HasOne(bc => bc.Story)
                .WithMany(c => c.CharacterStories)
                .HasForeignKey(bc => bc.StoryId);

            modelBuilder.Entity<ComicSerie>()
                .HasKey(bc => new { bc.ComicId, bc.SerieId });
            modelBuilder.Entity<ComicSerie>()
                .HasOne(bc => bc.Comic)
                .WithMany(b => b.ComicSeries)
                .HasForeignKey(bc => bc.ComicId);
            modelBuilder.Entity<ComicSerie>()
                .HasOne(bc => bc.Serie)
                .WithMany(c => c.ComicSeries)
                .HasForeignKey(bc => bc.SerieId);

            modelBuilder.Entity<ComicCreator>()
                .HasKey(bc => new { bc.ComicId, bc.CreatorId });
            modelBuilder.Entity<ComicCreator>()
                .HasOne(bc => bc.Comic)
                .WithMany(b => b.ComicCreators)
                .HasForeignKey(bc => bc.ComicId);
            modelBuilder.Entity<ComicCreator>()
                .HasOne(bc => bc.Creator)
                .WithMany(c => c.ComicCreators)
                .HasForeignKey(bc => bc.CreatorId);

            modelBuilder.Entity<ComicStory>()
                .HasKey(bc => new { bc.ComicId, bc.StoryId });
            modelBuilder.Entity<ComicStory>()
                .HasOne(bc => bc.Comic)
                .WithMany(b => b.ComicStories)
                .HasForeignKey(bc => bc.ComicId);
            modelBuilder.Entity<ComicStory>()
                .HasOne(bc => bc.Story)
                .WithMany(c => c.ComicStories)
                .HasForeignKey(bc => bc.StoryId);

            modelBuilder.Entity<ComicEvent>()
                .HasKey(bc => new { bc.ComicId, bc.EventId });
            modelBuilder.Entity<ComicEvent>()
                .HasOne(bc => bc.Comic)
                .WithMany(b => b.ComicEvents)
                .HasForeignKey(bc => bc.ComicId);
            modelBuilder.Entity<ComicEvent>()
                .HasOne(bc => bc.Event)
                .WithMany(c => c.ComicEvents)
                .HasForeignKey(bc => bc.EventId);

            modelBuilder.Entity<EventCreator>()
                .HasKey(bc => new { bc.EventId, bc.CreatorId });
            modelBuilder.Entity<EventCreator>()
                .HasOne(bc => bc.Event)
                .WithMany(b => b.EventCreators)
                .HasForeignKey(bc => bc.EventId);
            modelBuilder.Entity<EventCreator>()
                .HasOne(bc => bc.Creator)
                .WithMany(c => c.EventCreators)
                .HasForeignKey(bc => bc.CreatorId);

            modelBuilder.Entity<EventSerie>()
                .HasKey(bc => new { bc.EventId, bc.SerieId });
            modelBuilder.Entity<EventSerie>()
                .HasOne(bc => bc.Event)
                .WithMany(b => b.EventSeries)
                .HasForeignKey(bc => bc.EventId);
            modelBuilder.Entity<EventSerie>()
                .HasOne(bc => bc.Serie)
                .WithMany(c => c.EventSeries)
                .HasForeignKey(bc => bc.SerieId);

            modelBuilder.Entity<EventStory>()
                .HasKey(bc => new { bc.EventId, bc.StoryId });
            modelBuilder.Entity<EventStory>()
                .HasOne(bc => bc.Event)
                .WithMany(b => b.EventStories)
                .HasForeignKey(bc => bc.EventId);
            modelBuilder.Entity<EventStory>()
                .HasOne(bc => bc.Story)
                .WithMany(c => c.EventStories)
                .HasForeignKey(bc => bc.StoryId);

            modelBuilder.Entity<SerieCreator>()
                .HasKey(bc => new { bc.SerieId, bc.CreatorId });
            modelBuilder.Entity<SerieCreator>()
                .HasOne(bc => bc.Serie)
                .WithMany(b => b.SerieCreators)
                .HasForeignKey(bc => bc.SerieId);
            modelBuilder.Entity<SerieCreator>()
                .HasOne(bc => bc.Creator)
                .WithMany(c => c.SerieCreators)
                .HasForeignKey(bc => bc.CreatorId);

            modelBuilder.Entity<SerieStory>()
                .HasKey(bc => new { bc.SerieId, bc.StoryId });
            modelBuilder.Entity<SerieStory>()
                .HasOne(bc => bc.Serie)
                .WithMany(b => b.SerieStories)
                .HasForeignKey(bc => bc.SerieId);
            modelBuilder.Entity<SerieStory>()
                .HasOne(bc => bc.Story)
                .WithMany(c => c.SerieStories)
                .HasForeignKey(bc => bc.StoryId);

            modelBuilder.Entity<StoryCreator>()
                .HasKey(bc => new { bc.StoryId, bc.CreatorId });
            modelBuilder.Entity<StoryCreator>()
                .HasOne(bc => bc.Story)
                .WithMany(b => b.StoryCreators)
                .HasForeignKey(bc => bc.StoryId);
            modelBuilder.Entity<StoryCreator>()
                .HasOne(bc => bc.Creator)
                .WithMany(c => c.StoryCreators)
                .HasForeignKey(bc => bc.CreatorId);

            #endregion
        }

        #region [DbSet]

        public DbSet<Character> Characters { get; set; }
        public DbSet<CollectedIssue> CollectedIssues { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<CharacterComic> CharacterComics { get; set; }
        public DbSet<ComicDate> ComicDates { get; set; }
        public DbSet<ComicPrice> ComicPrices { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<ComicCreator> ComicCreators { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<CharacterEvent> CharacterEvents { get; set; }
        public DbSet<ComicEvent> ComicEvents { get; set; }
        public DbSet<EventCreator> EventCreators { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<EventSerie> EventSeries { get; set; }
        public DbSet<CharacterSerie> CharacterSeries { get; set; }
        public DbSet<ComicSerie> ComicSeries { get; set; }
        public DbSet<SerieCreator> SerieCreators { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<EventStory> EventStories { get; set; }
        public DbSet<ComicStory> ComicStories { get; set; }
        public DbSet<CharacterStory> CharacterStories { get; set; }
        public DbSet<SerieStory> SerieStories { get; set; }
        public DbSet<StoryCreator> StoryCreators { get; set; }
        public DbSet<TextObject> TextObjects { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Variant> Variants { get; set; }

        #endregion
    }
}
