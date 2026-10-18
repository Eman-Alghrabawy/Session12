using System;
using System.IO;
using System.Linq;

namespace Day_01_G03
{
    /// <summary>
    /// LINQ - Aggregate Operators: Count, Sum, Min, Max, Average, grouping counts ...
    /// </summary>
    static class AggregateOperators
    {
        public static void Run()
        {
            Console.WriteLine("\n===== LINQ - Aggregate Operators =====");

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // 1. Use Count to get the number of odd numbers in the array.
            Console.WriteLine("\n1. Number of odd numbers:");
            int oddCount = Arr.Count(n => n % 2 != 0);
            Console.WriteLine(oddCount);   // 5

            // 2. Return a list of customers and how many orders each has.
            // Select into an anonymous type holding the name and the length of the Orders array.
            Console.WriteLine("\n2. Customers and their number of orders:");
            var customerOrders = ListGenerator.CustomersList
                                 .Select(c => new { c.CustomerName, OrdersCount = c.Orders.Count() });
            foreach (var c in customerOrders)
                Console.WriteLine($"{c.CustomerName} => {c.OrdersCount} orders");

            // 3. Return a list of categories and how many products each has.
            // GroupBy category, then Count the products inside each group.
            Console.WriteLine("\n3. Categories and number of products:");
            var categoryCounts = ListGenerator.ProductsList
                                 .GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, ProductsCount = g.Count() });
            foreach (var c in categoryCounts)
                Console.WriteLine($"{c.Category} => {c.ProductsCount} products");

            // 4. Get the total of the numbers in an array.
            Console.WriteLine("\n4. Total of the numbers in the array:");
            Console.WriteLine(Arr.Sum());   // 45

            // ---- Dictionary questions (5-8) ----
            // Read dictionary_english.txt into an array of strings first (one word per line).
            string[] words = File.ReadAllLines("dictionary_english.txt");

            // 5. Total number of characters of all words.
            // (long) cast avoids int overflow on very large dictionaries.
            Console.WriteLine("\n5. Total number of characters in the dictionary:");
            Console.WriteLine(words.Sum(w => (long)w.Length));

            // 6. Length of the shortest word.
            Console.WriteLine("\n6. Length of the shortest word:");
            Console.WriteLine(words.Min(w => w.Length));

            // 7. Length of the longest word.
            Console.WriteLine("\n7. Length of the longest word:");
            Console.WriteLine(words.Max(w => w.Length));

            // 8. Average length of the words.
            Console.WriteLine("\n8. Average length of the words:");
            Console.WriteLine(words.Average(w => w.Length));
        }
    }
}
