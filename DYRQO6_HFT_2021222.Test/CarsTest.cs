using DYRQO6_HFT_2022231.Logic;
using DYRQO6_HFT_2022231.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYRQO6_HFT_2022231.Test
{
    [TestFixture]
    public class CarsTest
    {
        CarsLogic cl;
        [SetUp]
        public void Init()
        {
            cl = new CarsLogic(new FakeCarsRepository(), new FakeCustomersRepositroy(), new FakeCarShopRepositroy());
        }
        [Test]
        public void MostExpensiveCarTest()
        {
            //ACT
            var actual = cl.GetCustomerWithMostExpensiveCar();
            var expected = new IEnumerable<Customer>()
            {
                new Customer()
                {
                    //CustomerId = 4,
                    //Age = 50,
                    Name = "Isaiah Motley"
                    //Address = "217 Emeral Dreams Drive",
                    //Cars = null,
                    //Shop = null
                }
            };
                
            //ASSERT
            Assert.AreEqual(expected, actual);
        }
    }
}
