using System;

namespace Day_01_G03
{
    /// <summary>
    /// Represents a product in the store.
    /// Implements IComparable so products can be compared/sorted by price.
    /// </summary>
    class Product : IComparable<Product>
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        // Default ordering of products = by UnitPrice
        public int CompareTo(Product other)
            => this.UnitPrice.CompareTo(other?.UnitPrice);

        public override string ToString()
            => $"ProductID:{ProductID},ProductName:{ProductName},Category:{Category},UnitPrice:{UnitPrice},UnitsInStock:{UnitsInStock}";
    }
}
