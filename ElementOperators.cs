using System;
using System.Linq;

namespace Day_01_G03
{
    /// <summary>
    /// LINQ - Element Operators: return a single element (First, FirstOrDefault, ElementAt ...).
    /// </summary>
    static class ElementOperators
    {
        public static void Run()
        {
            Console.WriteLine("\n===== LINQ - Element Operators =====");

            // 1. Get first Product out of Stock.
            // First() throws if nothing matches (here there are out-of-stock products, so it is safe).
            Console.WriteLine("\n1. First product out of stock:");
            var firstOut = ListGenerator.ProductsList.First(p => p.UnitsInStock == 0);
            Console.WriteLine(firstOut);

            // 2. First product whose Price > 1000, or null if there is no match.
            // FirstOrDefault returns default(Product) = null instead of throwing.
            Console.WriteLine("\n2. First product with price > 1000 (null if none):");
            var firstExpensive = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(firstExpensive == null ? "null" : firstExpensive.ToString());

            // 3. Retrieve the second number greater than 5.
            // Filter numbers > 5 (9,8,6,7) then take the element at index 1 (the second one).
            Console.WriteLine("\n3. Second number greater than 5:");
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var second = Arr.Where(n => n > 5).ElementAt(1);
            Console.WriteLine(second);   // 8
        }
    }
}
