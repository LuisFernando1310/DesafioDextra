using DesafioDextra.Repositories;
using DesafioDextra.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioDextra.DTOs;

namespace DesafioDextra.Controllers
{
    [Route("/v1/public/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersRepository repository;

        public CharactersController(ICharactersRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("Create/Character")]
        public ActionResult<CharacterDTO> CreateCharacter(CreateCharacterDTO createCharacterDTO)
        {
            Character character = new Character
            {
                Id = Guid.NewGuid(),
                Name = createCharacterDTO.Name
            };

            repository.CreateCharacter(character);

            return character.AsDTO();
        }

        [HttpPost("Create/Comic")]
        public ActionResult<ComicDTO> CreateComic(CreateComicDTO createComicDTO)
        {
            try
            {
                ActionResult<CharacterDTO> checkCharacter = GetCharacter(Guid.Parse(createComicDTO.CharacterId));

                if (checkCharacter.Value == null)
                    throw new Exception("Não existe character com esse Id");

                Comic comic = new Comic
                {
                    Id = Guid.NewGuid(),
                    Title = createComicDTO.Title,
                    CharacterId = createComicDTO.CharacterId
                };

                repository.CreateComic(comic);

                return comic.AsDTO();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Create/Event")]
        public ActionResult<EventDTO> CreateEvent(CreateEventDTO createEventDTO)
        {
            try
            {
                ActionResult<CharacterDTO> checkCharacter = GetCharacter(Guid.Parse(createEventDTO.CharacterId));

                if (checkCharacter.Value == null)
                    throw new Exception("Não existe character com esse Id");

                Event events = new Event
                {
                    Id = Guid.NewGuid(),
                    Description = createEventDTO.Description,
                    CharacterId = createEventDTO.CharacterId,
                };

                repository.CreateEvent(events);

                return events.AsDTO();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Create/Serie")]
        public ActionResult<SerieDTO> CreateSerie(CreateSerieDTO createSerieDTO)
        {
            try
            {
                ActionResult<CharacterDTO> checkCharacter = GetCharacter(Guid.Parse(createSerieDTO.CharacterId));

                if (checkCharacter.Value == null)
                    throw new Exception("Não existe character com esse Id");

                Serie serie = new Serie
                {
                    Id = Guid.NewGuid(),
                    Title = createSerieDTO.Title,
                    CharacterId = createSerieDTO.CharacterId,
                };

                repository.CreateSerie(serie);

                return serie.AsDTO();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpPost("Create/Story")]
        public ActionResult<StoryDTO> CreateStory(CreateStoryDTO createStoryDTO)
        {
            try
            {
                ActionResult<CharacterDTO> checkCharacter = GetCharacter(Guid.Parse(createStoryDTO.CharacterId));

                if (checkCharacter.Value == null)
                    throw new Exception("Não existe character com esse Id");

                Story story = new Story
                {
                    Id = Guid.NewGuid(),
                    Resume = createStoryDTO.Resume,
                    CharacterId = createStoryDTO.CharacterId,
                };

                repository.CreateStory(story);

                return story.AsDTO();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<CharacterDTO> GetCharacters()
        {
            try
            {
                var characters = repository.GetCharacters().Select(character => character.AsDTO());

                if (characters == null)
                    throw new Exception("Não há nenhum character cadastrado");

                return characters;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{characterId}")]
        public ActionResult<CharacterDTO> GetCharacter(Guid characterId)
        {
            try
            {
                var character = repository.GetCharacter(characterId);
                if (character == null)
                    return NotFound();

                return character.AsDTO();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{characterId}/Comics")]
        public ActionResult<List<Comic>> GetComics(string characterId)
        {
            try
            {
                var comic = repository.GetComics(characterId);

                if (comic == null)
                    return NotFound();

                if (comic.Count == 0)
                    throw new Exception("Não foi possivel encontrar nenhuma comic com esse characterId");

                return comic;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{characterId}/Events")]
        public ActionResult<List<Event>> GetEvents(string characterId)
        {
            try
            {
                var events = repository.GetEvents(characterId);

                if (events == null)
                    return NotFound();

                if (events.Count == 0)
                    throw new Exception("Não foi possivel encontrar nenhum event com esse characterId");

                return events;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{characterId}/Series")]
        public ActionResult<List<Serie>> GetSeries(string characterId)
        {
            try
            {
                var serie = repository.GetSeries(characterId);

                if (serie == null)
                    return NotFound();

                if (serie.Count == 0)
                    throw new Exception("Não foi possivel encontrar nenhuma serie com esse characterId");

                return serie;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("{characterId}/Stories")]
        public ActionResult<List<Story>> GetStories(string characterId)
        {
            try
            {
                var story = repository.GetStories(characterId);

                if (story == null)
                    return NotFound();

                if (story.Count == 0)
                    throw new Exception("Não foi possivel encontrar nenhuma story com esse characterId");

                return story;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
