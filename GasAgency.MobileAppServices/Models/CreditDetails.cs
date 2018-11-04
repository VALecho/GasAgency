using MvvmHelpers;
using System;

namespace GasAgency.Models
{
    public class CreditDetail : ObservableObject
    {
        public string CreditDetailsId { get; set; }
        
        public Client Client { get; set; }

        public int Credit { get; set; }

        public int Deposit { get; set; }

        public int Balance { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
