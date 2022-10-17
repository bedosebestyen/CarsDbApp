using DYRQO6_HFT_2021222.Models;
using System.Linq;

namespace DYRQO6_HFT_2021222.Logic
{
    public interface ICarShopLogic
    {
        void Create(CarShop item);
        void Delete(int id);
        CarShop Read(int id);
        IQueryable<CarShop> ReadAll();
        void Update(CarShop item);
    }
}