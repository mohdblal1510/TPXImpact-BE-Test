namespace TextAdventureGame.App.Tests
{
    using System;
    using Moq;
    using TextAdventureGame.App.Interfaces;
    using TextAdventureGame.App.Services;
    using Xunit;

    public class GameServiceTests
    {
        private readonly Mock<IPlayerInput> mockInput;
        private readonly Game game;
        private readonly GameService gameService;

        public GameServiceTests()
        {
            mockInput = new Mock<IPlayerInput>();
            game = new Game(mockInput.Object);
            gameService = new GameService(game);
        }

        [Fact]
        public void TestGameStartsWithThreeHearts()
        {
            Assert.Equal(3, game.Hearts);
        }

        [Fact]
        public void TestLoseHeart()
        {
            game.LoseHeart();
            Assert.Equal(2, game.Hearts);
        }

        [Fact]
        public void TestRoom1_AttackGoblin_LoseHeart()
        {
            mockInput.Setup(input => input.GetInput()).Returns("1");
            var room = new Room1(); 
            room.Enter(game);
            Assert.Equal(2, game.Hearts);
        }

        [Fact]
        public void TestGameServiceProcessesRooms()
        {
            var roomMock = new Mock<IRoom>();
            gameService.ProcessRoom(roomMock.Object);
            roomMock.Verify(r => r.Enter(It.IsAny<Game>()), Times.Once);
        }

        [Fact]
        public void TestGameOverCondition()
        {
            game.LoseHeart();
            game.LoseHeart();
            game.LoseHeart();
            Assert.True(game.IsGameOver());
        }
    }
}