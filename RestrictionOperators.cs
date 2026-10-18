using System;
using System.Linq;

namespace Day_01_G03
{
    /// <summary>
    /// LINQ - Restriction Operators (Where): filter a sequence by a condition.
    /// </summary>
    static class RestrictionOperators
    {
        public static void Run()
        {
            Console.WriteLine("===== LINQ - Restriction Operators =====");

            // 1. Find all products that are out of stock.
            // Where keeps only the products whose UnitsInStock equals 0.
            Console.WriteLine("\n1. Products that are out of stock:");
            var outOfStock = ListGenerator.ProductsList.Where(p => p.UnitsInStock == 0);
            foreach (var p in outOfStock)
                Console.WriteLine(p);

            // 2. Find all products that are in stock and cost more than 3.00 per unit.
            // Two conditions combined with && : in stock (> 0) AND price > 3.00
            Console.WriteLine("\n2. Products in stock and cost more than 3.00:");
            var inStockExpensive = ListGenerator.ProductsList
                                   .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            foreach (var p in inStockExpensive)
                Console.WriteLine(p);

            // 3. Return digits whose name is shorter than their value.
            // The indexed overload of Where gives us (element, index).
            // Because the array is ordered zero..nine, the index IS the digit's value.
            Console.WriteLine("\n3. Digits whose name is shorter than their value:");
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortNames = Arr.Where((name, value) => name.Length < value);
            foreach (var d in shortNames)
                Console.WriteLine(d);   // expected: five, six, seven, eight, nine
        }
    }
}
