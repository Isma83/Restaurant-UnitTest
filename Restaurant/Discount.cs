using System;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Discount
    {
        private const decimal DiscountSummer = 0.10m;
        private const decimal DiscountWinter = 0.15m;


        public decimal CalculateTotalAfterDiscount(Product product) => CalculateTotalAfterDiscountInternal(product);

        public Task<decimal> CalculateTotalAfterDiscountAsync(Product product) => Task.Run(() => CalculateTotalAfterDiscountInternal(product));

        private decimal CalculateTotalAfterDiscountInternal(Product product)
        {
            if (product.Total == 0)
                throw new ArgumentException("Total should be bigger than zero.");

            if (DateTime.Now.Month == 2 || DateTime.Now.Month == 3)
            {
                return product.Total - (product.Total * DiscountSummer);
            }

            if (DateTime.Now.Month == 9 || DateTime.Now.Month == 10)
            {
                return product.Total - (product.Total * DiscountWinter);
            }

            return product.Total;
        }
    }
}
