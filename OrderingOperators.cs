using System;
using System.Linq;

namespace Day_01_G03
{
    /// <summary>
    /// LINQ - Ordering Operators: OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse.
    /// </summary>
    static class OrderingOperators
    {
        public static void Run()
        {
            Console.WriteLine("\n===== LINQ - Ordering Operators =====");

            string[] fruits = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            // 1. Sort a list of products by name.
            Console.WriteLine("\n1. Products sorted by name:");
            foreach (var p in ListGenerator.ProductsList.OrderBy(p => p.ProductName))
                Console.WriteLine(p);

            // 2. Case-insensitive sort of the words using a custom comparer.
            // OrderBy accepts an IComparer<TKey> as its second argument.
            Console.WriteLine("\n2. Words sorted case-insensitively (custom comparer):");
            foreach (var w in fruits.OrderBy(w => w, new CaseInsensitiveComparer()))
                Console.WriteLine(w);

            // 3. Sort products by units in stock from highest to lowest.
            Console.WriteLine("\n3. Products sorted by UnitsInStock (descending):");
            foreach (var p in ListGenerator.ProductsList.OrderByDescending(p => p.UnitsInStock))
                Console.WriteLine(p);

            // 4. Sort digits by the length of their name, then alphabetically by the name.
            // ThenBy is the secondary sort key (used when lengths are equal).
            Console.WriteLine("\n4. Digits sorted by name length then alphabetically:");
            foreach (var d in digits.OrderBy(d => d.Length).ThenBy(d => d))
                Console.WriteLine(d);

            // 5. Sort by word length, then case-insensitive alphabetical order.
            Console.WriteLine("\n5. Words sorted by length then case-insensitive:");
            foreach (var w in fruits.OrderBy(w => w.Length).ThenBy(w => w, new CaseInsensitiveComparer()))
                Console.WriteLine(w);

            // 6. Sort products by category, then by unit price from highest to lowest.
            Console.WriteLine("\n6. Products sorted by Category then UnitPrice (descending):");
            foreach (var p in ListGenerator.ProductsList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice))
                Console.WriteLine(p);

            // 7. Sort by word length, then case-insensitive DESCENDING order.
            Console.WriteLine("\n7. Words sorted by length then case-insensitive descending:");
            foreach (var w in fruits.OrderBy(w => w.Length).ThenByDescending(w => w, new CaseInsensitiveComparer()))
                Console.WriteLine(w);

            // 8. All digits whose second letter is 'i', in the REVERSE order of the original array.
            // Where filters (length check avoids index errors), Reverse flips the order.
            // Enumerable.Reverse is called explicitly to avoid ambiguity with newer array Reverse overloads.
            Console.WriteLine("\n8. Digits with 'i' as second letter (reversed):");
            var withI = Enumerable.Reverse(digits.Where(d => d.Length > 1 && d[1] == 'i'));
            foreach (var d in withI)
                Console.WriteLine(d);   // nine, six, five
        }
    }
}
