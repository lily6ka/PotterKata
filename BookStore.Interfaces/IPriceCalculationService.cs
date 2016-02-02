namespace BookStore.Interfaces
{
    public interface IPriceCalculationService
    {
        decimal CalculateOrderPrice(IOrder order);
    }
}
