using DesafioDextra.Controllers;
using DesafioDextra.DTOs;
using DesafioDextra.Entities;
using DesafioDextra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CharactersControllerTest
    {
        private readonly Mock<ICharactersRepository> repository = new Mock<ICharactersRepository>();

        [Fact]
        public void GetCharacter()
        {
            var controller = new CharactersController(repository.Object);

            var result = controller.GetCharacter(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateCharacter()
        {
            var characterToCreate = new CreateCharacterDTO()
            {
                Name = Guid.NewGuid().ToString()
            };

            var controller = new CharactersController(repository.Object);

            var result = controller.CreateCharacter(characterToCreate);

            Assert.IsType<CharacterDTO>(result.Value);
        }

        [Fact]
        public void GetComics()
        {
            var controller = new CharactersController(repository.Object);

            var result = controller.GetComics(Guid.NewGuid().ToString());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetEvents()
        {
            var controller = new CharactersController(repository.Object);

            var result = controller.GetEvents(Guid.NewGuid().ToString());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetSeries()
        {
            var controller = new CharactersController(repository.Object);

            var result = controller.GetSeries(Guid.NewGuid().ToString());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetStories()
        {
            var controller = new CharactersController(repository.Object);

            var result = controller.GetStories(Guid.NewGuid().ToString());

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
