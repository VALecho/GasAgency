using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class Product : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
