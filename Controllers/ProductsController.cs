using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softeng_integration_be.Provider;

namespace Softeng_integration_be.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductsProvider productsProvider = new();

		[HttpGet("{id}")]
		public ActionResult GetProductList(int id)
		{
			var data = productsProvider.GetProducts(id);

			if (data == null)
			{
				return NotFound();
			}

			return Ok(new { success = true, data = data.Result });
		}
	}
}
