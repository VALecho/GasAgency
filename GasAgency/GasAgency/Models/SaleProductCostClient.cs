using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class SaleProductCostClient
    {
        public Sale Sale { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }
        public ProductCost ProductCost { get; set; }
    }
}
