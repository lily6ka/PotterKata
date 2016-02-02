using BookStore.Interfaces;

namespace BookStore.Implementation
{
    public class Book : IBook
    {
        public Book()
        {
            Quantity = 1;
        }

        public BookEnum BookChapter { get; set; }

        public int Quantity { get; set; }
    }
}
