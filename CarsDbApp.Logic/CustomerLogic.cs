using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using System;
using System.Linq;
using System.Numerics;

namespace DYRQO6_HFT_2022231.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void Create(Customer item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Customer Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.repo.ReadAll(); ;
        }

        public void Update(Customer item)
        {
            this.repo.Create(item);
        }
    }
}
