using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Model
{
    public class Expense: ObservableObject
    {
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string cost;

        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }


    }
}
