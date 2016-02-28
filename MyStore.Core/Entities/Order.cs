using System.Collections.Generic;
using Common.Repository;
using MyStore.Core.Enums;

namespace MyStore.Core.Entities
{
    public class Order : EntityVersionable
    {
        public int OrderId { get; set; }
        public string OrderRefNumber { get; set; }
        public string Comment { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
    }
}
