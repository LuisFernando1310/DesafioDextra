using DesafioDextra.Entities;
using System;
using System.Collections.Generic;

namespace DesafioDextra.Repositories
{
    public interface ICharactersRepository
    {
        Character GetCharacter(Guid id);
        IEnumerable<Character> GetCharacters();
        List<Comic> GetComics(string characterid);
        List<Event> GetEvents(string characterid);
        List<Serie> GetSeries(string characterid);
        List<Story> GetStories(string characterid);
        void CreateCharacter(Character character);
        void CreateComic(Comic comic);
        void CreateEvent(Event events);
        void CreateSerie(Serie serie);
        void CreateStory(Story story);
    }
}