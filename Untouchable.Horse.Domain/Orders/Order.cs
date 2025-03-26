using System;
using System.Collections.Generic;
using System.Linq;
using Untouchable.Horse.Domain.Catalog;

namespace Untouchable.Horse.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice => Items.Sum(i => i.Price);
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public required Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price => Item.Price * Quantity;
    }
}
