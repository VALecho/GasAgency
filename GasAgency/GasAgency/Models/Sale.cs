using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class Sale : ObservableObject
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Ignore]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double Cost { get; set; }

        public TransactionMode TransactionMode { get; set; }

        public int ClientId { get; set; }

        [Ignore]
        public Client Client { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
