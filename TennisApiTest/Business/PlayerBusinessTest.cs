using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TennisApi.Business;
using TennisApi.Models;
using TennisApi.Repositories;
using Xunit;

namespace TennisApiTest.Business
{
    public class PlayerBusinessTest
    {
        private readonly PlayerBusiness Tested;
        private readonly Mock<IPlayerRepository> playerRepositoryMocked;

        public PlayerBusinessTest()
        {
            playerRepositoryMocked = new Mock<IPlayerRepository>();
            playerRepositoryMocked.Setup(mock => mock.GetPlayers())
                .Returns(new List<Player>()
                {
                    new Player(){ Id = 5, ShortName = "Djoko"},
                    new Player(){ Id = 3, ShortName = "Rafa"}
                });
            Tested = new PlayerBusiness(playerRepositoryMocked.Object);

        }

        [Fact]
        public void Test_GetPlayers_Should_ReturnOrderdPlayers()
        {
            var players = Tested.GetPlayers();
            players.Count.Should().Be(2);
            players[0].Id.Should().BeLessThan(players[1].Id);
        }

        [Theory]
        [InlineData(5, true)]
        [InlineData(167, false)]

        public void Test_DeletePlayer_Should_ExpectedResult(int id, bool result)
        {
             Tested.Delete(id).Should().Be(result);
        }

        [Fact]
        public void Test_GetPlayer_When_PlayerExist_Should_ReturnPlayer()
        {
            var player = Tested.GetPlayer(5);
            player.Should().NotBeNull();
            player.Id.Should().Be(5);
        }

        [Fact]
        public void Test_GetPlayer_When_PlayerExist_Should_ReturnNull()
        {
            var player = Tested.GetPlayer(555);
            player.Should().BeNull();
        }
    }
}
