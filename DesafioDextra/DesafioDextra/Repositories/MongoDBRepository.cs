using DesafioDextra.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDextra.Repositories
{
    public class MongoDBRepository : ICharactersRepository
    {
        private const string databaseName = "DesafioDextra";
        private const string collectionName = "Characters";
        private const string comicColletionName = "Comics";
        private const string eventColletionName = "Events";
        private const string serieColletionName = "Series";
        private const string storiesColletionName = "Stories";
        private readonly IMongoCollection<Character> charactersColletion;
        private readonly IMongoCollection<Comic> comicColletion;
        private readonly IMongoCollection<Event> eventColletion;
        private readonly IMongoCollection<Serie> serieColletion;
        private readonly IMongoCollection<Story> storiesColletion;


        public MongoDBRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            charactersColletion = database.GetCollection<Character>(collectionName);
            comicColletion = database.GetCollection<Comic>(comicColletionName);
            eventColletion = database.GetCollection<Event>(eventColletionName);
            serieColletion = database.GetCollection<Serie>(serieColletionName);
            storiesColletion = database.GetCollection<Story>(storiesColletionName);
        }

        public Character GetCharacter(Guid id)
        {
            var filter = Builders<Character>.Filter.Eq(character => character.Id, id);
            return charactersColletion.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Character> GetCharacters()
        {
            return charactersColletion.Find(new BsonDocument()).ToList();
        }

        public void CreateCharacter(Character character)
        {
            charactersColletion.InsertOne(character);
        }

        public List<Comic> GetComics(string characterid)
        {
            var filter = Builders<Comic>.Filter.Eq(comic => comic.CharacterId, characterid);
            return comicColletion.Find(filter).ToList();
        }

        public List<Event> GetEvents(string characterid)
        {
            var filter = Builders<Event>.Filter.Eq(events => events.CharacterId, characterid);
            return eventColletion.Find(filter).ToList();
        }

        public List<Serie> GetSeries(string characterid)
        {
            var filter = Builders<Serie>.Filter.Eq(serie => serie.CharacterId, characterid);
            return serieColletion.Find(filter).ToList();
        }

        public List<Story> GetStories(string characterid)
        {
            var filter = Builders<Story>.Filter.Eq(story => story.CharacterId, characterid);
            return storiesColletion.Find(filter).ToList();
        }

        public void CreateComic(Comic comic)
        {
            comicColletion.InsertOne(comic);
        }

        public void CreateEvent(Event events)
        {
            eventColletion.InsertOne(events);
        }

        public void CreateSerie(Serie serie)
        {
            serieColletion.InsertOne(serie);
        }

        public void CreateStory(Story story)
        {
            storiesColletion.InsertOne(story);
        }
    }
}
