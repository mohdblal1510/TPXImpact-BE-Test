using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TextAdventureGame.App;
using TextAdventureGame.App.Interfaces;
using TextAdventureGame.App.Services;

public class Startup
{
    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Register services
        services.AddSingleton<IPlayerInput, ConsolePlayerInput>();
        services.AddSingleton<Game>();
        services.AddSingleton<IGameService, GameService>();

        // Register rooms
        services.AddSingleton<IRoom, Room1>();
        services.AddSingleton<IRoom, Room2>();
        services.AddSingleton<IRoom, Room3>();
        services.AddSingleton<IRoom, Room4>();
        services.AddSingleton<IRoom, Room5>();

        return services.BuildServiceProvider();
    }
}
