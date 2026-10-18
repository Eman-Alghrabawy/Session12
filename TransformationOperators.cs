using System;
using System.Linq;

namespace Day_01_G03
{
    /// <summary>
    /// LINQ - Transformation Operators: Select, SelectMany (projection into new shapes).
    /// </summary>
    static class TransformationOperators
    {
        public static void Run()
        {
            Console.WriteLine("\n===== LINQ - Transformation Operators =====");

            // 1. Sequence of just the names of the products.
            Console.WriteLine("\n1. Product names:");
            foreach (var name in ListGenerator.ProductsList.Select(p => p.ProductName))
                Console.WriteLine(name);

            // 2. Upper and lower case version of each word (anonymous type).
            Console.WriteLine("\n2. Upper/Lower versions of words:");
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var cases = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            foreach (var c in cases)
                Console.WriteLine($"Upper: {c.Upper}, Lower: {c.Lower}");

            // 3. Some properties of Product, renaming UnitPrice to Price in the result.
            // In an anonymous type, "Price = p.UnitPrice" gives the property a new name.
            Console.WriteLine("\n3. Product properties (UnitPrice renamed to Price):");
            var productInfo = ListGenerator.ProductsList
                              .Select(p => new { p.ProductID, p.ProductName, Price = p.UnitPrice });
            foreach (var p in productInfo)
                Console.WriteLine($"ID: {p.ProductID}, Name: {p.ProductName}, Price: {p.Price}");

            // 4. Does each number's value match its position in the array?
            // Indexed Select gives (value, index); compare them.
            Console.WriteLine("\n4. Number in place? (value == position):");
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var inPlace = Arr.Select((num, index) => new { Number = num, InPlace = num == index });
            foreach (var x in inPlace)
                Console.WriteLine($"{x.Number}: {x.InPlace}");

            // 5. All pairs (a, b) with a from numbersA, b from numbersB and a < b.
            // Two "from" clauses = cross join (SelectMany); where filters the pairs.
            Console.WriteLine("\n5. Pairs where a < b:");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };
            foreach (var pair in pairs)
                Console.WriteLine($"{pair.a} is less than {pair.b}");

            // 6. All orders whose total is less than 500.00.
            // SelectMany flattens every customer's Orders array into a single sequence of orders.
            Console.WriteLine("\n6. Orders with total < 500:");
            var smallOrders = ListGenerator.CustomersList
                              .SelectMany(c => c.Orders)
                              .Where(o => o.Total < 500.00M);
            foreach (var o in smallOrders)
                Console.WriteLine(o);

            // 7. All orders made in 1998 or later.
            Console.WriteLine("\n7. Orders made in 1998 or later:");
            var recentOrders = ListGenerator.CustomersList
                               .SelectMany(c => c.Orders)
                               .Where(o => o.OrderDate.Year >= 1998);
            foreach (var o in recentOrders)
                Console.WriteLine(o);
        }
    }
}
