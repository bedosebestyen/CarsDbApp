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
        #region Manager
        static void Create(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter manager name: ");
                string name = Console.ReadLine();
                rest.Post(new Manager() { Name = name }, "manager");
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
        }
        static void Delete(string entity)
        {
            if (entity == "Manager")
            {
                Console.Write("Enter managers's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "manager");
            }
        }
        #endregion
        #region Customer
        static void Create(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter cutomer name: ");
                string name = Console.ReadLine();
                rest.Post(new Customer() { Name = name }, "customer");
            }
        }
        static void List(string entity)
        {
            if (entity == "Customer")
            {
                List<Manager> customers = rest.Get<Manager>("customer");
                foreach (var item in customers)
                {
                    Console.WriteLine(item.ManagerId + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter customers's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Manager one = rest.Get<Manager>(id, "customer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "customer");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Customer")
            {
                Console.Write("Enter customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "customer");
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
