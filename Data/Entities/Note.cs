using System;
using System.Collections.Generic;

namespace PrivateTasker.Data.Entities
{
	public class Note
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime NoteDate { get; set; }
		public IEnumerable<Reminder> Reminders { get; set; }
	}
}
