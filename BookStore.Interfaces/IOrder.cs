using System.Collections.Generic;

namespace BookStore.Interfaces
{
    public interface IOrder
    {
         List<IBook> Books { get; set; }
    }
}
