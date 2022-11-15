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
        public IEnumerable<object> GetCustomerWithMostExpensiveCar()
        {
            var query = from x in carsrepo.ReadAll()
                        from y in custrepo.ReadAll()
                        let MostExpensiveCar = carsrepo.ReadAll().Max(x => x.Price)
                        where x.Price == MostExpensiveCar && y.CustomerId == x.CustomerId
                        select new
                        {
                            Name = y.Name
                        };
            return query;
        }

        public IEnumerable<object> GetCarPurchaseDate(string name)
        {
            return from x in carsrepo.ReadAll()
                   from y in custrepo.ReadAll()
                   where y.Name == name 
                   && x.CustomerId == y.CustomerId
                   select new
                   {
                       Date = x.PurchaseDate.Year,
                       Name = y.Name,
                       CarType = x.CarType
                   };
        }

        public IEnumerable<CustomerInfo> GetYoungestWithCar()
        {

            return from x in carsrepo.ReadAll()
                   from y in shoprepo.ReadAll()
                   from t in custrepo.ReadAll()
                   let youngest = custrepo.ReadAll().Min(t => t.Age)
                   where youngest == t.Age && t.CustomerId == x.CustomerId && x.ShopId == y.ShopId
                   select new CustomerInfo
                   {
                       Name = t.Name,
                       Age = t.Age,
                       CarType = x.CarType,
                       CarShop = y.Name
                   };
        }

        public IEnumerable<object> MostExpensiveCarInSpecifiedShop(string name)
        {
            return from x in carsrepo.ReadAll()
                   from y in shoprepo.ReadAll()
                   let Car = carsrepo.ReadAll().Max(x => x.Price)
                   where y.Name == name && x.Price == Car && x.ShopId == y.ShopId
                   select new
                   {
                       CarType = x.CarType,
                       Price = x.Price,
                       Shop = y.Name
                   };
        }
    }
    public class CustomerInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CarType { get; set; }
        public string CarShop { get; set; }


        public override bool Equals(object obj)
        {
            Customer b = obj as Customer;
            Cars c = obj as Cars;
            CarShop r = obj as CarShop;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Name == b.Name
                    && this.Age == b.Age
                    && this.CarType == c.CarType
                    && this.CarShop == r.Name;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Age, this.CarType, this.CarShop);
        }
    }
}
