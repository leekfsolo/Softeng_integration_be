using Microsoft.EntityFrameworkCore;
using Softeng_integration_be.Models;

namespace Softeng_integration_be.Provider
{
	public class ProductsProvider : BaseProvider
	{
		public async Task<Category> GetProducts(int id)
		{
			return await db.Categories.Where(category => category.Id == id).Include(category => category.Products).AsNoTracking().FirstAsync();
		}
	}
}
