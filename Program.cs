using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PrivateTasker.Data;
using Microsoft.Extensions.DependencyInjection;

namespace PrivateTasker
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);

			if (args.Length == 1 && args[0].ToLower() == "/seed")
			{
				RunSeeding(host);

			}
			else
			{
				host.Run();
			}
		}

		private static void RunSeeding(IWebHost host)
		{
			var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

			using (var scope = scopeFactory.CreateScope())
			{
				var seeder = scope.ServiceProvider.GetService<TaskerSeeder>();
				seeder.Seed();
			}
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(SetupConfiguration)
				.UseStartup<Startup>()
			.Build();

		private static void SetupConfiguration(WebHostBuilderContext ctx,
			IConfigurationBuilder builder)
		{
			builder.Sources.Clear();
			builder.AddJsonFile("config.json", false, true)
				.AddEnvironmentVariables();
		}
	}
}
