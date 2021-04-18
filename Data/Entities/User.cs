using System.Collections.Generic;

namespace PrivateTasker.Data.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Nickname { get; set; }
		public string Password { get; set; }
		public IEnumerable<Note> Notes { get; set; }
	}
}
