using DYRQO6_HFT_2022231.Logic;
using DYRQO6_HFT_2022231.Models;
using DYRQO6_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DYRQO6_HFT_2022231.Test
{
    [TestFixture]
    public class CarsTest
    {
        CarsLogic cl;
        CarShopLogic csl;
        Mock<IRepository<Cars>> mockCarsRepo;
        Mock<IRepository<CarShop>> mockShopRepo;
        Mock<IRepository<Customer>> mockCustRepo;
        Mock<IRepository<Manager>> mockManRepo;
        [SetUp]
        public void Init()
        {
            #region mockok
            mockCarsRepo = new Mock<IRepository<Cars>>();
            mockCarsRepo.Setup(c => c.ReadAll()).Returns(new List<Cars>()
            {
                new Cars("1#Audi#white#1#1#2019*04*15#10000000"),
                new Cars("2#Skoda#king blue#2#2#2009*04*15#5000000"),
                new Cars("3#Volkswagen#black#3#3#2022*01*30#6000000"),
                new Cars("4#Fiat#red#4#3#2000*09*19#3000000"),
                new Cars("5#BMW#black#4#1#2020*02*22#11000000"),
                new Cars("6#Peugeot#white#1#1#2014*06*08#4000000"),
            }.AsQueryable());

            mockShopRepo = new Mock<IRepository<CarShop>>();
            mockShopRepo.Setup(t => t.ReadAll()).Returns(new List<CarShop>()
            {
                new CarShop("1#Best cars#5#3300 Fittro Street#1"),
                new CarShop("2#Awesome machines#4#1714 Mulberry Lane#2"),
                new CarShop("3#Carscarscars#10#3799 Marie Street#3")
            }.AsQueryable());

            mockCustRepo = new Mock<IRepository<Customer>>();
            mockCustRepo.Setup(x => x.ReadAll()).Returns(new List<Customer>()
            {
                new Customer("1#25#Winton Dickinson#695 Willison Street"),
                new Customer("2#22#Osmond Chambers#2111 Sand Fork Road"),
                new Customer("3#31#Talia Cooke#2390 Carriage Court"),
                new Customer("4#50#Isaiah Motley#217 Emeral Dreams Drive")
            }.AsQueryable());

            mockManRepo = new Mock<IRepository<Manager>>();
            mockManRepo.Setup(x => x.ReadAll()).Returns(new List<Manager>()
            {
                new Manager("1#Pradip Xanthippe#500000#36#1"),
                new Manager("2#Lorrin Matthei#600000#47#2"),
                new Manager("3#Rúni Surayya#800000#59#3")
            }.AsQueryable());
            cl = new CarsLogic(mockCarsRepo.Object, mockCustRepo.Object, mockShopRepo.Object);
            csl = new CarShopLogic(mockShopRepo.Object, mockManRepo.Object);
            #endregion
        }
        [Test]
        public void MostExpensiveCarTest()
        {
            //ACT
            var actual = cl.GetCustomerWithMostExpensiveCar().ToList();

            //ASSERT
            Assert.That(actual[0].GetHashCode(), Is.EqualTo(new {Name = "Isaiah Motley" }.GetHashCode()));
        }
        [Test]
        public void HighestPaidManagerTest()
        {
            //ACT
            var actual = csl.GetHighestPaidManager().ToList();

            //ASSERT
            Assert.That(actual[0].GetHashCode(), Is.EqualTo(new {Name = "Rúni Surayya", Salary = 800000, Shop = "Carscarscars" }.GetHashCode()));
        }
        [Test]
        public void WhenDidTheCustomerBuyTheCarTest()
        {
            //ACT
            var actual = cl.GetCarPurchaseDate("Osmond Chambers").ToList();
            //ASSERT
            Assert.That(actual[0].GetHashCode(), Is.EqualTo(new { Date = 2009, Name = "Osmond Chambers", CarType = "Skoda" }.GetHashCode()));
        }
        [Test]
        public void YoungestCustomerWithCarTest()
        {
            //ACT
            var actual = cl.GetYoungestWithCar().ToList();

            var expected = new List<CustomerInfo>() 
            {
                new CustomerInfo()
                {
                    Name = "Osmond Chambers",
                    Age = 22,
                    CarType = "Skoda",
                    CarShop = "Awesome machines"
                }
            };
            //ASSERT
            Assert.That(actual[0].GetHashCode(), Is.EqualTo(new CustomerInfo() { Age = 22, CarShop = "Awesome machines",
                CarType = "Skoda", Name = "Osmond Chambers"}.GetHashCode()));
            ;
        }
        [Test]
        public void MostExpensiveCarInSpecifiedShopTest()
        {
            var actual = cl.MostExpensiveCarInSpecifiedShop("Best cars").ToList();

            Assert.That(actual[0].GetHashCode(), Is.EqualTo(new { CarType = "BMW", Price = 11000000, Shop = "Best cars" }.GetHashCode()));
        }

    }
}
