using System;
using Moq;
using Xunit;
using System.Collections.Generic;
using TextAdventureGame.App.Interfaces;
using TextAdventureGame.App.Services;
using TextAdventureGame.App;

public class GameServiceTests
{
    private readonly Mock<IPlayerInput> mockInput;
    private readonly Game game;
    private readonly Mock<IRoom> mockRoom;
    private readonly Mock<IGameService> mockGameService;
    private readonly IGameService gameService;

    public GameServiceTests()
    {
        mockInput = new Mock<IPlayerInput>();
        game = new Game(mockInput.Object);
        mockRoom = new Mock<IRoom>();
        mockGameService = new Mock<IGameService>();

        var rooms = new List<IRoom> { new Room1(), new Room2(), new Room3(), new Room4(), new Room5() };
        gameService = new GameService(game, rooms);
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
    public void TestEndGameMethod()
    {
        game.EndGame();
        Assert.True(game.IsGameOver());
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
    public void TestRoom3_EatDrink_AddsToInventory()
    {
        mockInput.Setup(input => input.GetInput()).Returns("1");
        var room = new Room3();
        room.Enter(game);
        Assert.True(game.Inventory.ContainsKey("Rested"));
    }

    [Fact]
    public void TestRoom3_IgnoreTable_EndsGame()
    {
        mockInput.Setup(input => input.GetInput()).Returns("2");
        var room = new Room3();
        room.Enter(game);
        Assert.True(game.IsGameOver());
    }

    [Fact]
    public void TestGameServiceProcessesRoom()
    {
        gameService.ProcessRoom(mockRoom.Object);
        mockRoom.Verify(r => r.Enter(It.IsAny<Game>()), Times.Once);
    }

    [Fact]
    public void TestGameServicePlayCallsProcessRoom()
    {
        mockGameService.Object.Play();
        mockGameService.Verify(gs => gs.Play(), Times.Once);
    }
}
