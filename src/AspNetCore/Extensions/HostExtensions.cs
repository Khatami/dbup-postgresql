using DbUp;
using System.Data.Common;
using System.Reflection;

namespace AspNetCore.Extensions
{
	public static class HostExtensions
	{
		public static IHost MigrateDatabase<TContext>(this IHost host)
		{
			using (var serviceScope = host.Services.CreateScope())
			{
				var configuration = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();

				var connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("SampleDB");

				var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<TContext>>();

				// If you want your application to create the database for you, add the following line
				EnsureDatabase.For.PostgresqlDatabase(connectionString);

				var upgrader = DeployChanges.To
					.PostgresqlDatabase(connectionString)
					.WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly())
					.LogToConsole()
					.Build();

				var result = upgrader.PerformUpgrade();

				if (result.Successful == false)
				{
					logger.LogError(result.Error, "Migrating database failed");
					throw new Exception("Migrating database failed");
				}

				return host;
			}
		}
	}
}
