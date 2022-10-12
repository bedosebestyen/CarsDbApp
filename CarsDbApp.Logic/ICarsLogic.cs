using CarsDbApp.Models;
using System.Linq;

namespace CarsDbApp.Logic
{
    public interface ICarsLogic
    {
        void Create(Cars item);
        void Delete(int id);
        Cars Read(int id);
        IQueryable<Cars> ReadAll();
        void Update(Cars item);
    }
}