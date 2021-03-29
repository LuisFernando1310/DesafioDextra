using DesafioDextra.DTOs;
using DesafioDextra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDextra
{
    public static class Extensions
    {
        public static CharacterDTO AsDTO(this Character character)
        {
            return new CharacterDTO
            {
                Id = character.Id,
                Name = character.Name
            };
        }

        public static ComicDTO AsDTO(this Comic comic)
        {
            return new ComicDTO
            {
                Id = comic.Id,
                Title = comic.Title,
                CharacterId = comic.CharacterId
            };
        }

        public static EventDTO AsDTO(this Event events)
        {
            return new EventDTO
            {
                Id = events.Id,
                Description = events.Description,
                CharacterId = events.CharacterId
            };
        }

        public static SerieDTO AsDTO(this Serie serie)
        {
            return new SerieDTO
            {
                Id = serie.Id,
                Title = serie.Title,
                CharacterId = serie.CharacterId
            };
        }

        public static StoryDTO AsDTO(this Story story)
        {
            return new StoryDTO
            {
                Id = story.Id,
                Resume = story.Resume,
                CharacterId = story.CharacterId
            };
        }
    }
}
