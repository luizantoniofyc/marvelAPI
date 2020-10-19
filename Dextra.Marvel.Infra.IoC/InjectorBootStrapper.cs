using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Interfaces.Repository;
using Dextra.Marvel.Application.UseCases;
using Dextra.Marvel.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.IoC
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICharacterUseCase, CharacterUseCase>();
            services.AddScoped<IComicUseCase, ComicUseCase>();
            services.AddScoped<IEventUseCase, EventUseCase>();
            services.AddScoped<ISerieUseCase, SerieUseCase>();
            services.AddScoped<IStoryUseCase, StoryUseCase>();

            // Infra - Data
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IComicRepository, ComicRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<IStoryRepository, StoryRepository>();
        }
    }
}
