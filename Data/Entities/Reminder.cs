using System;

namespace PrivateTasker.Data.Entities
{
	public class Reminder
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }
	}
}
