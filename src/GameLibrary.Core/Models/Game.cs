using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Core.Models;

public class Game
{
	public Guid Id { get; set; }
	
	public string Title { get; set; } = string.Empty;

	public int ReleaseYear { get; set; }

	public GameStatus Status { get; set; }

	public virtual Genre Genre { get; set; }

	public virtual Platform Platform { get; set; }
}
