using DYRQO6_HFT_2022231.Logic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DYRQO6_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCRUDController
    {
        ICarShopLogic carShopLogic;
        ICarsLogic carsLogic;

        public NonCRUDController(ICarShopLogic carShopLogic, ICarsLogic carsLogic)
        {
            this.carShopLogic = carShopLogic;
            this.carsLogic = carsLogic;
        }

        [HttpGet]
        public IEnumerable<object> GetHighestPaidManager()
        {
            return this.carShopLogic.GetHighestPaidManager();
        }

        [HttpGet]
        public IEnumerable<object> GetCustomerWithMostExpensiveCar()
        {
            return this.carsLogic.GetCustomerWithMostExpensiveCar();
        }

        [HttpGet("{name}")]
        public IEnumerable<object> GetCarPurchaseDate(string name)
        {
            return carsLogic.GetCarPurchaseDate(name);
        }

        [HttpGet]
        public IEnumerable<CustomerInfo> GetYoungestWithCar()
        {
            return this.carsLogic.GetYoungestWithCar();
        }

        [HttpGet("{name}")]
        public IEnumerable<object> MostExpensiveCarInSpecifiedShop(string name)
        {
            return this.carsLogic.MostExpensiveCarInSpecifiedShop(name);
        }
    }
}
