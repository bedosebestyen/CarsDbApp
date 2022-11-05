using DYRQO6_HFT_2022231.Logic;
using DYRQO6_HFT_2022231.Models;
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
        [SetUp]
        public void Init()
        {
            cl = new CarsLogic(new FakeCarsRepository(), new FakeCustomersRepositroy(), new FakeCarShopRepositroy());
            csl = new CarShopLogic(new FakeCarShopRepositroy(), new FakeManagerRepository());
        }
        [Test]
        public void MostExpensiveCarTest()
        {
            //ACT
            var actual = cl.GetCustomerWithMostExpensiveCar();

            //ASSERT
            Assert.That(actual, Is.EqualTo(new {Name = "Isaiah Motley" }));
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
                    Name = "Winton Dickinson",
                    Age = 20,
                    CarType = "Audi",
                    CarShop = "Best Cars"
                },
                new CustomerInfo()
                {
                    Name = "Winton Dickinson",
                    Age = 20,
                    CarType = "Peugeot",
                    CarShop = "Best Cars"
                }
                
            };
            //ASSERT
            Assert.AreEqual(expected, actual);
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
