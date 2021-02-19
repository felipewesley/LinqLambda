using System;
using System.Collections.Generic;
using GenericsApp.Service;
using GenericsApp.Entities;

namespace GenericsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            CalculationService calculationService = new CalculationService();

            for (int index = 1; index <= n; index++)
            {
                Console.Write("Enter a value of a product (name,value): ");
                Product prod = new Product(Console.ReadLine());

                list.Add(prod);
            }

            Console.WriteLine("Max value: " + calculationService.Max(list));
        }

    }
}
