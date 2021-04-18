using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrivateTasker.Data.Entities;
using System;

namespace PrivateTasker.Data
{
	public class TaskerContext : DbContext
	{
		public TaskerContext(DbContextOptions<TaskerContext> options) : base(options)
		{
		}

		public DbSet<Note> Notes { get; set; }
		public DbSet<Reminder> Reminders { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
