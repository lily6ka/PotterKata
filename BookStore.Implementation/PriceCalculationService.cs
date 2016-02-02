using System.Collections.Generic;
using System.Linq;
using BookStore.Interfaces;

namespace BookStore.Implementation
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private const decimal FixedBookPrice = 8;

        private static readonly Dictionary<int, int> DiscountRate = new Dictionary<int, int>
        {
            {2, 5},
            {3, 10},
            {4, 15},
            {5, 25},
            {6, 30},
            {7, 35},
        };

        public decimal CalculateOrderPrice(IOrder order)
        {
            if (order != null && order.Books.Count > 0)
            {
                int uniqueSeries = order.Books.GroupBy(_ => _.BookChapter).Count();
                int discountRate;

                if (DiscountRate.ContainsKey(uniqueSeries))
                {
                    discountRate = DiscountRate[uniqueSeries];
                }
                else
                {
                    discountRate = 0;
                }

                int booksCount = order.Books.Sum(_ => _.Quantity);

                if (discountRate > 0)
                {
                    return CalculateFullPriceSeries(booksCount) - CalculateDiscountPrice(uniqueSeries, discountRate);
                }

                return CalculateFullPriceSeries(booksCount);
            }
            return 0;
        }

        private static decimal CalculateDiscountPrice(int uniqueSeries, int discountRate)
        {
            return ((uniqueSeries * FixedBookPrice * discountRate) / 100);
        }

        private decimal CalculateFullPriceSeries(int fullPriceBooksCount)
        {
            if (fullPriceBooksCount > 0)
            {
                return fullPriceBooksCount * FixedBookPrice;
            }

            return 0;
        }
    }
}
