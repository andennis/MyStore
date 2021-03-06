﻿using System.Data.Entity.ModelConfiguration;
using MyStore.Core.Entities;

namespace MyStore.Repository.Mapping
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration(string dbScheme)
        {
            ToTable("Order", dbScheme);
            Property(x => x.Version).IsConcurrencyToken();
            Property(x => x.OrderRefNumber).HasMaxLength(64);
            HasRequired(x => x.Client).WithMany().HasForeignKey(x => x.ClientId).WillCascadeOnDelete(false);
        }
    }
}
