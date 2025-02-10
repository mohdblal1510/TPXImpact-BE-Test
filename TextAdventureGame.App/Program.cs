using TextAdventureGame.App.Services;
using TextAdventureGame.App;

public class Program
{
    public static void Main()
    {
        var game = new Game(new ConsolePlayerInput());
        var gameService = new GameService(game);
        gameService.Play();
    }
}