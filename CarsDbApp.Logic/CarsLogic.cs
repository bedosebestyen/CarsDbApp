using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DYRQO6_HFT_2022231.Logic
{
    public class CarsLogic : ICarsLogic
    {
        IRepository<Cars> carsrepo;
        IRepository<Customer> custrepo;
        IRepository<CarShop> shoprepo;

        public CarsLogic(IRepository<Cars> carsrep, IRepository<Customer> custrep, IRepository<CarShop> shoprep)
        {
            carsrepo = carsrep;
            custrepo = custrep;
            shoprepo = shoprep;
        }

        public void Create(Cars item)
        {
            carsrepo.Create(item);
        }

        public void Delete(int id)
        {
            carsrepo.Delete(id);
        }

        public Cars Read(int id)
        {
            return carsrepo.Read(id);
        }

        public IQueryable<Cars> ReadAll()
        {
            return carsrepo.ReadAll(); ;
        }

        public void Update(Cars item)
        {
            carsrepo.Create(item);
        }
        public IEnumerable<Customer> GetCustomerWithMostExpensiveCar()
        {

            var query = from x in carsrepo.ReadAll()
                        from t in custrepo.ReadAll()
                        let MostExpensiveCar = carsrepo.ReadAll().Max(x => x.Price)
                        where x.Price == MostExpensiveCar && t.CustomerId == x.CustomerId
                        select new Customer()
                        {
                            Name = t.Name
                        };
            return query;
        }

    }
}
