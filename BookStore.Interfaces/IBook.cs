namespace BookStore.Interfaces
{
    public interface IBook
    {
        BookSeriesEnum Series { get; set; }

        int Quantity { get; set; }
    }
}
