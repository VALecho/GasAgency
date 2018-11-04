using MvvmHelpers;
using SQLite;
using System;

namespace GasAgency.Models
{
    public class ProductCost : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ProductCostId { get; set; }

        public int ProductId { get; set; }

        [Ignore]
        public Product Product { get; set; }

        public double Cost { get; set; }

        public DateTime EffectiveFrom { get; set; }
    }
}
