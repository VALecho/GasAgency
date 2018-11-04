using MvvmHelpers;
using System;

namespace GasAgency.Models
{
    public class ProductCost : ObservableObject
    {
        public string ProductCostId { get; set; }
        
        public Product Product { get; set; }

        public double Cost { get; set; }

        public DateTime EffectiveFrom { get; set; }
    }
}
