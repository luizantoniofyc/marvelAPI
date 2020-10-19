using System.Net;
using System.Threading.Tasks;
using Dextra.Marvel.Api.Controllers._Shared;
using Dextra.Marvel.Application.Interfaces;
using Dextra.Marvel.Application.Models;
using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Input;
using Dextra.Marvel.Application.Models.Serie;
using Dextra.Marvel.Application.Models.Story;
using Microsoft.AspNetCore.Mvc;

namespace Dextra.Marvel.Api.V1.Controllers
{
    public class CharacterController : BaseController
    {
        private readonly ICharacterUseCase _characterUseCase;
        private readonly IComicUseCase _comicUseCase;
        private readonly IEventUseCase _eventUseCase;
        private readonly ISerieUseCase _serieUseCase;
        private readonly IStoryUseCase _storyUseCase;

        public CharacterController(
            ICharacterUseCase characterUseCase,
            IComicUseCase comicUseCase,
            IEventUseCase eventUseCase,
            ISerieUseCase serieUseCase,
            IStoryUseCase storyUseCase)
        {
            _characterUseCase = characterUseCase;
            _comicUseCase = comicUseCase;
            _eventUseCase = eventUseCase;
            _serieUseCase = serieUseCase;
            _storyUseCase = storyUseCase;
        }

        /// <summary>
        /// Fetches lists of comic characters with optional filters.
        /// </summary>
        /// <param name="apiVersion">API version. It`s automatically populated if using URL versioning.</param>
        /// <param name="characterInput">Character filters</param>
        /// <returns>Fetches lists of characters.</returns>
        [Produces("application/json")]
        [HttpGet, Route("v{version:apiVersion}/characters")]
        [ProducesResponseType(typeof(CharacterDataWrapper), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> GetCharacters(ApiVersion apiVersion, [FromQuery] CharacterInput characterInput)
        {
            return Ok(await _characterUseCase.GetListAsync(characterInput));
        }


        /// <summary>
        /// This method fetches a single character resource. It is the canonical URI for any character resource provided by the API.
        /// </summary>
        /// <param name="apiVersion">API version. It`s automatically populated if using URL versioning.</param>
        /// <param name="characterId">A single character id.</param>
        /// <returns>Fetches a single character by id.</returns>
        [Produces("application/json")]
        [HttpGet, Route("v{version:apiVersion}/characters/{characterId}")]
        [ProducesResponseType(typeof(CharacterDataWrapper), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCharacterById(ApiVersion apiVersion, int characterId)
        {
            return Ok(await _characterUseCase.GetByIdAsync(new CharacterInput() { CharacterId = characterId, Limit = 10, Offset = 0 }));
        }

        /// <summary>
        /// Fetches lists of comics containing a specific character, with optional filters.
        /// </summary>
        /// <param name="apiVersion">API version. It`s automatically populated if using URL versioning.</param>
        /// <param name="characterId">A single character id.</param>
        /// <param name="comicInput">Comic filters</param>
        /// <returns>Fetches lists of comics filtered by a character id.</returns>
        [Produces("application/json")]
        [HttpGet, Route("v{version:apiVersion}/characters/{characterId}/comics")]
        [ProducesResponseType(typeof(ComicDataWrapper), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> GetCharacterComics(ApiVersion apiVersion, int characterId, [FromQuery] ComicInput comicInput)
        {
            return Ok(await _comicUseCase.GetListAsync(characterId, comicInput));
        }

        /// <summary>
        /// Fetches lists of events in which a specific character appears, with optional filters.
        /// </summary>
        /// <param name="apiVersion">API version. It`s automatically populated if using URL versioning.</param>
        /// <param name="characterId">Schedule unique identifier (e.g. 123456)</param>
        /// <param name="eventInput">Event filters</param>
        /// <returns>Fetches lists of events filtered by a character id.</returns>
        [Produces("application/json")]
        [HttpGet, Route("v{version:apiVersion}/characters/{characterId}/events")]
        [ProducesResponseType(typeof(EventDataWrapper), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> GetCharacterEvents(ApiVersion apiVersion, int characterId, [FromQuery] EventInput eventInput)
        {
            return Ok(await _eventUseCase.GetListAsync(characterId, eventInput));
        }

        /// <summary>
        /// Fetches lists of comic series in which a specific character appears, with optional filters.
        /// </summary>
        /// <param name="apiVersion">API version. It`s automatically populated if using URL versioning.</param>
        /// <param name="characterId">Schedule unique identifier (e.g. 123456)</param>
        /// <param name="serieInput">Serie filters</param>
        /// <returns>Fetches lists of series filtered by a character id.</returns>
        [Produces("application/json")]
        [HttpGet, Route("v{version:apiVersion}/characters/{characterId}/series")]
        [ProducesResponseType(typeof(SerieDataWrapper), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> GetCharacterSeries(ApiVersion apiVersion, int characterId, [FromQuery] SerieInput serieInput)
        {
            return Ok(await _serieUseCase.GetListAsync(characterId, serieInput));
        }

        /// <summary>
        /// Fetches lists of comic stories featuring a specific character with optional filters.
        /// </summary>
        /// <param name="apiVersion">API version. It`s automatically populated if using URL versioning.</param>
        /// <param name="characterId">Schedule unique identifier (e.g. 123456)</param>
        /// <param name="storyInput">Story filters</param>
        /// <returns>Fetches lists of stories filtered by a character id.</returns>
        [Produces("application/json")]
        [HttpGet, Route("v{version:apiVersion}/characters/{characterId}/stories")]
        [ProducesResponseType(typeof(StoryDataWrapper), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> GetCharacterStories(ApiVersion apiVersion, int characterId, [FromQuery] StoryInput storyInput)
        {
            return Ok(await _storyUseCase.GetListAsync(characterId, storyInput));
        }
    }
}