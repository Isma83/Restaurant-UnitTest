using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class OrderController : ControllerBase
    {
        private readonly Discount _order = new Discount();

        /// <summary>
        /// Calculates the <see cref="Product"/> discount.
        /// </summary>
        /// <param name="product">Instance of <see cref="Product"/>.</param>
        /// <returns>The total with discount.</returns>
        [HttpPost]
        public decimal TotalWithDiscount(Product product)
        {
            return _order.CalculateProductDiscount(product);
        }
    }
}
