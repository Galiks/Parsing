using Entity;
using System.Collections.Generic;

namespace DAL
{
    public interface ILetyShopsDAO
    {
        int AddData(LetyShops letyShops, int id);
        int AddShop(Shop shop);
        IEnumerable<LetyShops> GetDiscounts();
    }
}