using CarsDbApp.Models;
using System.Linq;

namespace CarsDbApp.Logic
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