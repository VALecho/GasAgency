using MvvmHelpers;
using System;

namespace GasAgency.Models
{
    public class Sale : ObservableObject
    {

        public int Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double Cost { get; set; }

        public TransactionMode TransactionMode { get; set; }

        public Client Client { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
