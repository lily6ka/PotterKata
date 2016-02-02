using BookStore.Interfaces;

namespace BookStore.Implementation
{
    public class Book : IBook
    {
        public Book()
        {
            Quantity = 1;
        }

        public BookSeriesEnum Series { get; set; }

        public int Quantity { get; set; }
    }
}
