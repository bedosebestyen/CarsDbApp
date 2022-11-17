using ConsoleTools;
using DYRQO6_HFT_2022231.Client;
using DYRQO6_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace DYRQO6_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;
        #region CRUDAPI
        static void Create(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter manager name: ");
                string name = Console.ReadLine();
                rest.Post(new Manager() { Name = name }, "manager");
            }
            else if (entity == "Customer")
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();
                rest.Post(new Customer() { Name = name }, "customer");
            }
            else if (entity == "Cars")
            {
                Console.Write("Enter car brand): ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter car price: ");
                int price = int.Parse(Console.ReadLine());
                rest.Post(new Cars() { CarType = name , Price = price}, "cars");
            }
            else if (entity == "CarShop")
            {
                Console.Write("Enter a shop name): ");
                string name = Console.ReadLine();
                rest.Post(new CarShop() { Name = name}, "carshop");
            }
        }
        static void List(string entity)
        {
            if (entity == "Manager")
            {
                List<Manager> managers = rest.Get<Manager>("manager");
                foreach (var item in managers)
                {
                    Console.WriteLine(item.ManagerId + ": " + item.Name);
                }
            }
            Console.ReadLine();

            if (entity == "Customer")
            {
                List<Customer> customers = rest.Get<Customer>("customer");
                foreach (var item in customers)
                {
                    Console.WriteLine(item.CustomerId + ": " + item.Name);
                }
            }
            Console.ReadLine();

            if (entity == "Cars")
            {
                List<Cars> cars = rest.Get<Cars>("cars");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.CarId + ": " + item.CarType + " price:" + item.Price);
                }
            }
            Console.ReadLine();

            if (entity == "CarShop")
            {
                List<CarShop> cars = rest.Get<CarShop>("carshop");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.ShopId + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter manager's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Manager one = rest.Get<Manager>(id, "manager");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "manager");
            }

            else if (entity == "Customer")
            {
                Console.Write("Enter customers's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Customer one = rest.Get<Customer>(id, "customer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "customer");
            }

            else if (entity == "Cars")
            {
                Console.Write("Enter the Id of the car you want to update: ");
                int id = int.Parse(Console.ReadLine());
                Cars one = rest.Get<Cars>(id, "cars");
                Console.Write($"New car brand [old: {one.CarType}]: ");
                string brand = Console.ReadLine();
                one.CarType = brand;
                rest.Put(one, "cars");
            }

            else if (entity == "CarShop")
            {
                Console.Write("Enter the id of the shop you want to update: ");
                int id = int.Parse(Console.ReadLine());
                CarShop one = rest.Get<CarShop>(id, "carshop");
                Console.Write($"New shop name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "carshop");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter managers's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "manager");
            }
            else if (entity == "Customer")
            {
                Console.Write("Enter customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "customer");
            }
            else if (entity == "Cars")
            {
                Console.Write("Enter the id of the car you want to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "cars");
            }

            else if (entity == "CarShop")
            {
                Console.Write("Enter the id of the shop you want to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "carshop");
            }
        }
        #endregion
        
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:18906/", "cars");

            var managerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Manager"))
                .Add("Create", () => Create("Manager"))
                .Add("Delete", () => Delete("Manager"))
                .Add("Update", () => Update("Manager"))
                .Add("Exit", ConsoleMenu.Close);

            var shopSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("CarShop"))
                .Add("Create", () => Create("CarShop"))
                .Add("Delete", () => Delete("CarShop"))
                .Add("Update", () => Update("CarShop"))
                .Add("Exit", ConsoleMenu.Close);

            var carsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Cars"))
                .Add("Create", () => Create("Cars"))
                .Add("Delete", () => Delete("Cars"))
                .Add("Update", () => Update("Cars"))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Customers", () => customerSubMenu.Show())
                .Add("Cars", () => carsSubMenu.Show())
                .Add("Managers", () => managerSubMenu.Show())
                .Add("Shops", () => shopSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
