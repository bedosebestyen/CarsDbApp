using CarsDbApp.Models;
using System.Linq;

namespace CarsDbApp.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);
    }
}