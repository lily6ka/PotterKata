namespace BookStore.Interfaces
{
    public interface IBook
    {
        BookEnum BookChapter { get; set; }

        int Quantity { get; set; }
    }
}
