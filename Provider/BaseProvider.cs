using Microsoft.EntityFrameworkCore;
using Softeng_integration_be.Data;

namespace Softeng_integration_be.Provider
{
	public class BaseProvider
	{
		public DataContext db;

		public BaseProvider()
		{
			DbContextOptionsBuilder<DataContext> optionsBuilder = new();
			optionsBuilder.UseNpgsql("${YOUR_CONNECTION_STRING}");
			db = new DataContext(optionsBuilder.Options);
		}
		public async Task<bool> SaveDataAsync()
		{
			await db.SaveChangesAsync();
			return true;

		}
	}
}
