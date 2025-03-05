using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Core.Contracts.Services;
using GameLibrary.Core.Models;
using GameLibrary.Core.Data;

namespace GameLibrary.Core.Services;

public class DataService(GameLibraryDataContext dbContext) : IDataService
{
	public async Task<Game> AddGameAsync(Game game)
	{
		var newGame = new Game
		{
			Id = Guid.NewGuid(),
			Title = game.Title,
			ReleaseYear = game.ReleaseYear,
			Status = game.Status,
			Genre = game.Genre,
			Platform = game.Platform
		};

		dbContext.Games.Add(newGame);
		await dbContext.SaveChangesAsync();

		return await Task.FromResult(game);
	}

	public async Task<Genre> AddGenreAsync(Genre genre)
	{
		var newGenre = new Genre
		{
			Id = Guid.NewGuid(),
			Name = genre.Name
		};

		dbContext.Genres.Add(newGenre);
		await dbContext.SaveChangesAsync();

		return await Task.FromResult(genre);
	}

	public async Task<Platform> AddPlatformAsync(Platform platform)
	{
		var newPlatform = new Platform
		{
			Id = Guid.NewGuid(),
			Name = platform.Name
		};

		dbContext.Platforms.Add(newPlatform);
		await dbContext.SaveChangesAsync();

		return await Task.FromResult(platform);
	}

	public async Task DeleteGameAsync(Guid id)
	{
		dbContext.Games.Remove(dbContext.Games.Find(id));
		await dbContext.SaveChangesAsync();
	}

	public async Task DeleteGenreAsync(Guid id)
	{
		dbContext.Genres.Remove(dbContext.Genres.Find(id));
		await dbContext.SaveChangesAsync();
	}

	public async Task DeletePlatformAsync(Guid id)
	{
		dbContext.Platforms.Remove(dbContext.Platforms.Find(id));
		await dbContext.SaveChangesAsync();
	}

	public Task<Game> GetGameAsync(Guid id)
	{
		var game = dbContext.Games.Find(id) ?? throw new KeyNotFoundException($"Game with Id {id} not found.");

		return Task.FromResult(game);
	}

	public Task<IEnumerable<Game>> GetGamesAsync()
	{
		return Task.FromResult(dbContext.Games.AsEnumerable());
	}

	public Task<Genre> GetGenreAsync(Guid id)
	{
		var genre = dbContext.Genres.Find(id) ?? throw new KeyNotFoundException($"Genre with Id {id} not found.");

		return Task.FromResult(genre);
	}

	public Task<IEnumerable<Genre>> GetGenresAsync()
	{
		return Task.FromResult(dbContext.Genres.AsEnumerable());
	}

	public Task<Platform> GetPlatformAsync(Guid id)
	{
		var platform = dbContext.Platforms.Find(id) ?? throw new KeyNotFoundException($"Platform with Id {id} not found.");

		return Task.FromResult(platform);
	}

	public Task<IEnumerable<Platform>> GetPlatformsAsync()
	{
		return Task.FromResult(dbContext.Platforms.AsEnumerable());
	}

	public async Task<Game> UpdateGameAsync(Game game)
	{
		var existingGame = dbContext.Games.Find(game.Id) ?? throw new KeyNotFoundException($"Game with Id {game.Id} not found.");

		existingGame.Title = game.Title;
		existingGame.ReleaseYear = game.ReleaseYear;
		existingGame.Status = game.Status;
		existingGame.Genre = game.Genre;
		existingGame.Platform = game.Platform;

		var updatedGame = dbContext.Update(existingGame);
		await dbContext.SaveChangesAsync();

		return await Task.FromResult(updatedGame.Entity);
	}

	public async Task<Genre> UpdateGenreAsync(Genre genre)
	{
		var existingGenre = dbContext.Genres.Find(genre.Id) ?? throw new KeyNotFoundException($"Genre with Id {genre.Id} not found.");

		existingGenre.Name = genre.Name;

		var updatedGenre = dbContext.Update(existingGenre);
		await dbContext.SaveChangesAsync();

		return await Task.FromResult(updatedGenre.Entity);
	}

	public async Task<Platform> UpdatePlatformAsync(Platform platform)
	{
		var existingPlatform = dbContext.Platforms.Find(platform.Id) ?? throw new KeyNotFoundException($"Platform with Id {platform.Id} not found.");

		existingPlatform.Name = platform.Name;
		
		var updatedPlatform = dbContext.Update(existingPlatform);
		await dbContext.SaveChangesAsync();

		return await Task.FromResult(dbContext.Update(existingPlatform).Entity);
	}
}
