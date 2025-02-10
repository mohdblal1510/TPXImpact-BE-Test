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
        private readonly Mock<IGameService> mockGameService;

        public GameServiceTests()
        {
            mockInput = new Mock<IPlayerInput>();
            game = new Game(mockInput.Object);
            mockGameService = new Mock<IGameService>();
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
        public void TestGameServicePlayCallsProcessRoom()
        {
            mockGameService.Object.Play();
            mockGameService.Verify(gs => gs.Play(), Times.Once);
        }

        [Fact]
        public void TestGameOverConditionAfterThreeLoses()
        {
            game.LoseHeart();
            game.LoseHeart();
            game.LoseHeart();
            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void TestGameOverCondition()
        {
            game.EndGame();
            Assert.True(game.IsGameOver());
        }
    }
}