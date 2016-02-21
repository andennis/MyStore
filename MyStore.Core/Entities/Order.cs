﻿using Common.Repository;

namespace MyStore.Core.Entities
{
    public class Order : EntityVersionable
    {
        public int OrderId { get; set; }
        public string OrderRefNumber { get; set; }
        public string Comment { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}