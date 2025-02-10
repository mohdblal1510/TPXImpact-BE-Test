using TextAdventureGame.App.Services;
using TextAdventureGame.App;
using TextAdventureGame.App.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new Startup().ConfigureServices();
        var gameService = serviceProvider.GetRequiredService<IGameService>();

        var game = new Game(new ConsolePlayerInput());
        var rooms = new List<IRoom> { new Room1(), new Room2(), new Room3(), new Room4(), new Room5() };
        gameService.Play();
    }
}