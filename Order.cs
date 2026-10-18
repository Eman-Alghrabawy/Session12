using System;

namespace Day_01_G03
{
    /// <summary>
    /// Represents a single order placed by a customer.
    /// </summary>
    class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public Order(int orderID, DateTime orderDate, decimal total)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            Total = total;
        }

        // Parameterless constructor (needed for object initializers in ListGenerator)
        public Order() { }

        public override string ToString()
            => $"Order Id: {OrderID}, Date: {OrderDate.ToShortDateString()}, Total: {Total}";
    }
}
