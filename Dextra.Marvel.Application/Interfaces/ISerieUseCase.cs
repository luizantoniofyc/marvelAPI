using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Serie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Application.Interfaces
{
    public interface ISerieUseCase : IDisposable
    {
        Task<SerieDataWrapper> GetListAsync(int characterId, SerieInput serieInput);
    }
}
