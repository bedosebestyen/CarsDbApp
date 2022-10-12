using CarsDbApp.Logic;
using CarsDbApp.Repository;
using System;

namespace CarsDbApp.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ctx = new CarsDbContext();

            var carRepo = new CarsRepository(ctx);
            var carShopRepo = new CarShopRepository(ctx);
            var customerRepo = new CustomerRepository(ctx);

            var carLogic = new CarsLogic(carRepo);
            var carShopLogic = new CarShopLogic(carShopRepo);
            var customerLogic = new CustomerLogic(customerRepo);

            var items = carLogic.ReadAll();
            ;
        }
    }
}
