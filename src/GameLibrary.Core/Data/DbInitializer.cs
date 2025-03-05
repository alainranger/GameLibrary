using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Core.Models;

namespace GameLibrary.Core.Data;

public static class DbInitializer
{
	public static void Initialize(GameLibraryDataContext context)
	{
		// Look for any students.
		if (context.Games.Any())
		{
			return;   // DB has been seeded
		}

		var platforms = new Platform[]
		{
			new() { Id = Guid.NewGuid(), Name = "PC" },
			new() { Id = Guid.NewGuid(), Name = "PlayStation" },
			new() { Id = Guid.NewGuid(), Name = "Xbox" },
			new() { Id = Guid.NewGuid(), Name = "Nintendo" },
			new() { Id = Guid.NewGuid(), Name = "Mobile" },
		};

		context.Platforms.AddRange(platforms);
		context.SaveChanges();

		var genres = new Genre[]
		{
			new() { Id = Guid.NewGuid(), Name = "Action" },
			new() { Id = Guid.NewGuid(), Name = "Adventure" },
			new() { Id = Guid.NewGuid(), Name = "RPG" },
			new() { Id = Guid.NewGuid(), Name = "Simulation" },
			new() { Id = Guid.NewGuid(), Name = "Strategy" },
		};

		context.Genres.AddRange(genres);
		context.SaveChanges();

		var games = new Game[]
		{
			new() { Id = Guid.NewGuid(), Title = "The Witcher 3: Wild Hunt", Platform = platforms.First(x => x.Name == "PC"), Genre = genres.First(x => x.Name == "RPG"), ReleaseYear = 2015, Status = GameStatus.NotStarted },
			new() { Id = Guid.NewGuid(), Title = "The Legend of Zelda: Breath of the Wild", Platform = platforms.First(x => x.Name == "Nintendo"), Genre = genres.First(x => x.Name == "RPG"), ReleaseYear = 2017, Status = GameStatus.NotStarted },
			new() { Id = Guid.NewGuid(), Title = "Red Dead Redemption 2", Platform = platforms.First(x => x.Name == "PlayStation"), Genre = genres.First(x => x.Name == "Action"), ReleaseYear = 2018, Status = GameStatus.NotStarted },
			new() { Id = Guid.NewGuid(), Title = "The Elder Scrolls V: Skyrim", Platform = platforms.First(x => x.Name == "PC"), Genre = genres.First(x => x.Name == "RPG"), ReleaseYear = 2011, Status = GameStatus.NotStarted },
			new() { Id = Guid.NewGuid(), Title = "Grand Theft Auto V", Platform = platforms.First(x => x.Name == "PC"), Genre = genres.First(x => x.Name == "Action"), ReleaseYear = 2013, Status = GameStatus.NotStarted },
		};

		context.Games.AddRange(games);
		context.SaveChanges();
	}
}
