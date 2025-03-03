using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Core.Contracts.Services;
using GameLibrary.Core.Models;

namespace GameLibrary.Core.Services;

public class SampleDataService : IDataService
{
	private static readonly List<Platform> _platforms =
		[
			new Platform { Id = Guid.NewGuid(), Name = "PC" },
			new Platform { Id = Guid.NewGuid(), Name = "PlayStation" },
			new Platform { Id = Guid.NewGuid(), Name = "Xbox" },
			new Platform { Id = Guid.NewGuid(), Name = "Nintendo" },
			new Platform { Id = Guid.NewGuid(), Name = "Mobile" },
		];

	private static readonly List<Genre> _genres =
		[
			new Genre { Id = Guid.NewGuid(), Name = "Action" },
			new Genre { Id = Guid.NewGuid(), Name = "Adventure" },
			new Genre { Id = Guid.NewGuid(), Name = "RPG" },
			new Genre { Id = Guid.NewGuid(), Name = "Simulation" },
			new Genre { Id = Guid.NewGuid(), Name = "Strategy" },
		];

	private static readonly List<Game> _games =
		[
			new Game { Id = Guid.NewGuid(), Title = "The Witcher 3: Wild Hunt", Platform = _platforms.First(x => x.Name == "PC"), Genre = _genres.First(x => x.Name == "RPG"), ReleaseYear = 2015, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "The Legend of Zelda: Breath of the Wild", Platform = _platforms.First(x => x.Name == "Nintendo"), Genre = _genres.First(x => x.Name == "RPG"), ReleaseYear = 2017, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "Red Dead Redemption 2", Platform = _platforms.First(x => x.Name == "PlayStation"), Genre = _genres.First(x => x.Name == "Action"), ReleaseYear = 2018, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "The Elder Scrolls V: Skyrim", Platform = _platforms.First(x => x.Name == "PC"), Genre = _genres.First(x => x.Name == "RPG"), ReleaseYear = 2011, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "Grand Theft Auto V", Platform = _platforms.First(x => x.Name == "PC"), Genre = _genres.First(x => x.Name == "Action"), ReleaseYear = 2013, Status = GameStatus.NotStarted },
		];

	public async Task<IEnumerable<Platform>> GetPlatformsAsync()
		=> await Task.FromResult(_platforms).ConfigureAwait(true);

	public async Task<Platform> GetPlatformAsync(Guid id)
		=> await Task.Run(() => _platforms.Find(p => p.Id == id) ?? throw new KeyNotFoundException($"Platform with Id {id} not found."))
			.ConfigureAwait(true);

	public async Task<Platform> AddPlatformAsync(Platform platform)
	{
		if(platform == null)
		{
			throw new ArgumentNullException(nameof(platform));
		}

		var newPlatform = new Platform
		{
			Id = Guid.NewGuid(),
			Name = platform.Name
		};

		_platforms.Add(newPlatform);

		return await Task.FromResult(newPlatform).ConfigureAwait(true);
	}

	public Task DeletePlatformAsync(Guid id)
	{
		var platform = _platforms.Find(p => p.Id == id) ?? throw new KeyNotFoundException($"Platform with Id {id} not found.");

		_platforms.Remove(platform);

		return Task.CompletedTask;
	}

	public Task<Platform> UpdatePlatformAsync(Platform platform)
	{
		if(platform == null)
		{
			throw new ArgumentNullException(nameof(platform));
		}

		var existingPlatform = _platforms.Find(p => p.Id == platform.Id) ?? throw new KeyNotFoundException($"Platform with Id {platform.Id} not found.");
		existingPlatform.Name = platform.Name;

		return Task.FromResult(existingPlatform);
	}

	public async Task<IEnumerable<Genre>> GetGenresAsync()
		=> await Task.FromResult(_genres).ConfigureAwait(true);

	public async Task<Genre> GetGenreAsync(Guid id)
		=> await Task.Run(() => _genres.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Genre with Id {id} not found."))
			.ConfigureAwait(true);

	public async Task<Genre> AddGenreAsync(Genre genre)
	{
		if(genre == null)
		{
			throw new ArgumentNullException(nameof(genre));
		}

		var newGenre = new Genre
		{
			Id = Guid.NewGuid(),
			Name = genre.Name
		};

		_genres.Add(newGenre);

		return await Task.FromResult(newGenre).ConfigureAwait(true);
	}

	public Task DeleteGenreAsync(Guid id)
	{
		var genre = _genres.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Genre with Id {id} not found.");

		_genres.Remove(genre);

		return Task.CompletedTask;
	}

	public Task<Genre> UpdateGenreAsync(Genre genre)
	{
		if(genre == null)
		{
			throw new ArgumentNullException(nameof(genre));
		}

		var existingGenre = _genres.Find(g => g.Id == genre.Id) ?? throw new KeyNotFoundException($"Genre with Id {genre.Id} not found.");
		existingGenre.Name = genre.Name;

		return Task.FromResult(existingGenre);
	}

	public async Task<IEnumerable<Game>> GetGamesAsync()
		=> await Task.FromResult(_games).ConfigureAwait(true);

	public async Task<Game> GetGameAsync(Guid id)
		=> await Task.Run(() =>_games.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Game with Id {id} not found."))
		.ConfigureAwait(true);

	public async Task<Game> AddGameAsync(Game game)
	{
		if(game == null)
		{
			throw new ArgumentNullException(nameof(game));
		}

		var newGame = new Game
		{
			Id = Guid.NewGuid(),
			Title = game.Title,
			Platform = game.Platform,
			Genre = game.Genre,
			ReleaseYear = game.ReleaseYear,
			Status = game.Status
		};

		_games.Add(newGame);

		return await Task.FromResult(newGame).ConfigureAwait(true);
	}

	public Task DeleteGameAsync(Guid id)
	{
		var game = _games.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Game with Id {id} not found.");

		_games.Remove(game);

		return Task.CompletedTask;
	}

	public Task<Game> UpdateGameAsync(Game game)
	{
		if (game == null)
		{
			throw new ArgumentNullException(nameof(game));
		}

		var existingGame = _games.Find(g => g.Id == game.Id) ?? throw new KeyNotFoundException($"Game with Id {game.Id} not found.");
		existingGame.Title = game.Title;
		existingGame.Platform = game.Platform;
		existingGame.Genre = game.Genre;
		existingGame.ReleaseYear = game.ReleaseYear;
		existingGame.Status = game.Status;

		return Task.FromResult(existingGame);
	}
}

