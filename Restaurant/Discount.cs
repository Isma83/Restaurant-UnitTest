﻿using System;

namespace Restaurant
{
    public class Discount
    {
        private const decimal DiscountSummer = 0.10m;
        private const decimal DiscountWinter = 0.15m;


        public decimal CalculateProductDiscount(Product product)
        {
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