using System;
using AutoLotDALCore.DataInitialization;
using AutoLotDALCore.EF;
using AutoLotDALCore.Models;
using AutoLotDALCore.Repos;

namespace AutoLotDALCore.TestDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AutoLotContext())
            {
                MyDataInitializer.RecreateDatabase(context);
                MyDataInitializer.InitializeData(context);
                foreach (Inventory c in context.Cars)
                {
                    Console.WriteLine(c);
                }
            }

            Console.WriteLine("---------------------------------");

            using (var repo = new InventoryRepo())
            {
                foreach (Inventory c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }

            Console.ReadLine();
        }
    }
}
