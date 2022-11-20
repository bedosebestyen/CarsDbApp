﻿using DYRQO6_HFT_2022231.Models;
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
                        let MostExpensiveCar = carsrepo.ReadAll().Max(x => x.Price)
                        where x.Price == MostExpensiveCar && x.Customer.CustomerId == x.CustomerId
                        select new
                        {
                            Name = x.Customer.Name
                        };

            return query;
        }

        public IEnumerable<object> GetCarPurchaseDate(string name)
        {
            return from x in carsrepo.ReadAll()
                   where x.Customer.Name == name 
                   && x.CustomerId == x.Customer.CustomerId
                   select new
                   {
                       Date = x.PurchaseDate.Year,
                       Name = x.Customer.Name,
                       CarType = x.CarType
                   };
        }

        public IEnumerable<CustomerInfo> GetYoungestWithCar()
        {
            var youngest = custrepo.ReadAll().Min(t => t.Age);
            return from x in carsrepo.ReadAll()
                   where youngest == x.Customer.Age && x.Customer.CustomerId == x.CustomerId && x.ShopId == x.Shop.ShopId
                   select new CustomerInfo
                   {
                       Name = x.Customer.Name,
                       Age = x.Customer.Age,
                       CarType = x.CarType,
                       CarShop = x.Shop.Name
                   };
        }

        public IEnumerable<object> MostExpensiveCarInSpecifiedShop(string name)
        {
            return from x in carsrepo.ReadAll()
                   let Car = carsrepo.ReadAll().Max(x => x.Price)
                   where x.Shop.Name == name && x.Price == Car && x.ShopId == x.Shop.ShopId
                   select new
                   {
                       CarType = x.CarType,
                       Price = x.Price,
                       Shop = x.Shop.Name
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
