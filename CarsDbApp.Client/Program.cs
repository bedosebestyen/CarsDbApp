using DYRQO6_HFT_2021222.Logic;
using DYRQO6_HFT_2021222.Repository;
using System;

namespace DYRQO6_HFT_2021222.Client
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
