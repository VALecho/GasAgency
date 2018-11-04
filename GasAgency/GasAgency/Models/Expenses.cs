using MvvmHelpers;
using System;

namespace GasAgency.Models
{
    public class Expense : ObservableObject
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
