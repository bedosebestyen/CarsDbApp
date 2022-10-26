using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Logic
{
    public class CarsLogic : ICarsLogic
    {
        IRepository<Cars> repo;

        public CarsLogic(IRepository<Cars> repo)
        {
            this.repo = repo;
        }

        public void Create(Cars item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Cars Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Cars> ReadAll()
        {
            return this.repo.ReadAll(); ;
        }

        public void Update(Cars item)
        {
            this.repo.Create(item);
        }
        public IEnumerable<Customer> GetCustomerWithMostExpensiveCar()
        {
            var expensiveCar = from cars in this.repo.ReadAll()
                         let MostExpensiveCar = this.repo.ReadAll().Max(x => x.Price)
                         where cars.Price == MostExpensiveCar
                         select cars;
            var customer = from cars in this.repo.ReadAll()
                           join ecar in expensiveCar on cars.CarId equals ecar.CarId
                           where ecar.CarId == cars.CarId
                           select cars.Customer;
            return customer;
        }

    }
}
