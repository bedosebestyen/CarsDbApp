using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Test
{
    public class FakeCarsRepository : IRepository<Cars>
    {
        public void Create(Cars item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cars Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cars item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Cars> ReadAll()
        {
            return new List<Cars>()
            {
                new Cars("1#Audi#white#1#1#2019*04*15#10000000"),
                new Cars("2#Skoda#king blue#2#2#2009*04*15#5000000"),
                new Cars("3#Volkswagen#black#3#3#2022*01*30#6000000"),
                new Cars("4#Fiat#red#4#3#2000*09*19#3000000"),
                new Cars("5#BMW#black#4#1#2020*02*22#11000000"),
                new Cars("6#Peugeot#white#1#1#2014*06*08#4000000"),
            }.AsQueryable();
        }
    }
    public class FakeCustomersRepositroy : IRepository<Customer>
    {
        public void Create(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> ReadAll()
        {
            return new List<Customer>()
            {
                new Customer("1#20#Winton Dickinson#695 Willison Street"),
                new Customer("2#40#Osmond Chambers#2111 Sand Fork Road"),
                new Customer("3#31#Talia Cooke#2390 Carriage Court"),
                new Customer("4#50#Isaiah Motley#217 Emeral Dreams Drive")
            }.AsQueryable();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
    public class FakeCarShopRepositroy : IRepository<CarShop>
    {
        public void Create(CarShop item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CarShop Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CarShop> ReadAll()
        {
            return new List<CarShop>()
            {
                new CarShop("1#Best cars#5#3300 Fittro Street#1"),
                new CarShop("2#Awesome machines#4#1714 Mulberry Lane#2"),
                new CarShop("3#Carscarscars#10#3799 Marie Street#3")
            }.AsQueryable();
        }

        public void Update(CarShop item)
        {
            throw new NotImplementedException();
        }
    }
}
