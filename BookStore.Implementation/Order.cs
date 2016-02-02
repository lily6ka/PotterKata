using System.Collections.Generic;
using BookStore.Interfaces;

namespace BookStore.Implementation
{
    public class Order : IOrder
    {
        public Order()
        {
            Books = new List<IBook>();
        }

        public List<IBook> Books { get; set; }
    }
}
