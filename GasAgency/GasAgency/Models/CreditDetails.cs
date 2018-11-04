using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class CreditDetail : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public string CreditDetailsId { get; set; }

        public int ClientId { get; set; }

        [Ignore]
        public Client Client { get; set; }

        public int Credit { get; set; }

        public int Deposit { get; set; }

        public int Balance { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
