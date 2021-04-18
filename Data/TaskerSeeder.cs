using Microsoft.AspNetCore.Hosting;
using PrivateTasker.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrivateTasker.Data
{
	public class TaskerSeeder
	{
		private readonly TaskerContext ctx;
		private readonly IWebHostEnvironment env;

		public TaskerSeeder(TaskerContext ctx, IWebHostEnvironment env)
		{
			this.ctx = ctx;
			this.env = env;
		}

		public void Seed()
		{
			ctx.Database.EnsureCreated();
			if (!ctx.Reminders.Any())
			{
				// Need to create sample data
				var filePath = Path.Combine(env.ContentRootPath, "Data/art.json");
				var json = File.ReadAllText(filePath);
				var reminders = JsonSerializer.Deserialize<IEnumerable<Reminder>>(json);

				ctx.Reminders.AddRange(reminders);

				var note = new Note
				{
					Title = "First Note",
					Content = "Test content",
					NoteDate = DateTime.Today,
					Reminders = new List<Reminder>
					{
						new Reminder
						{
							Message = "Test reminder message",
							Date = DateTime.Today
						}
					}
				};

				ctx.Notes.Add(note);

				ctx.SaveChanges();
			}
		}
	}
}
