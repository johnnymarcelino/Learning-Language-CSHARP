﻿using Linq.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*

            // Introduce to the Linq

            // Specify the data source
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };

            // Define the query
            var result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10);

            // Define the query
            // with lists 
            List<int> result2 = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10).ToList();  // tolist cause IEnumerable don't convert to list

            // Define the query
            // with IEnumerable
            IEnumerable<int> result3 = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10); // IEnumerable is generic in to a lista for multiple collections

            // Execute the query
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }

            */

            Category category = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category category1 = new Category() { Tier = 1, Name = "Computers", Id = 2 };
            Category category2 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.00, Category = category1 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.00, Category = category },
                new Product() { Id = 3, Name = "TV", Price = 1700.00, Category = category2 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.00, Category = category1 },
                new Product() { Id = 5, Name = "Saw", Price = 80.00, Category = category },
                new Product() { Id = 6, Name = "Tablet", Price = 700.00, Category = category1 },
                new Product() { Id = 7, Name = "Camera", Price = 700.00, Category = category2 },
                new Product() { Id = 8, Name = "Printer", Price = 350.00, Category = category2 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.00, Category = category1 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.00, Category = category2 },
                new Product() { Id = 11, Name = "Level", Price = 70.00, Category = category },
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            Print("TIER 1 AND PRICE < 900.00: ", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAME OF PRODUCTS FROM TOOLS: ", r2);

            //var r3 = products.Where(p => p.Name[0] == 'C').Select(p => p.Name + " " + p.Price + " " + p.Category.Name);
            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });  // object as alias and anonnymous object
            Print("NAME STARTED WITH 'C' AND ANONNYMOUS OBJECT: ", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            var r6 = products.First();
            Console.WriteLine("First test1: " + r6);
        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

    }
}
