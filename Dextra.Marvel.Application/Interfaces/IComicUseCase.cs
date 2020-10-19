using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces
{
    public interface IComicUseCase : IDisposable
    {
        Task<ComicDataWrapper> GetListAsync(int characterId, ComicInput comicInput);
    }
}
