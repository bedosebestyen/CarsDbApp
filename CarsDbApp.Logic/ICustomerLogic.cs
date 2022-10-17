using DYRQO6_HFT_2021222.Models;
using System.Linq;

namespace DYRQO6_HFT_2021222.Logic
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