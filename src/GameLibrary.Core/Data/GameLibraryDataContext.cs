using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Core.Data;

public class GameLibraryDataContext(DbContextOptions<GameLibraryDataContext> options) : DbContext(options)
{
	public DbSet<Game> Games { get; set; }
	public DbSet<Platform> Platforms { get; set; }
	public DbSet<Genre> Genres { get; set; }
}
