using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace GasAgency.Model
{
    public class Sales: ObservableObject
    {
        private string product;

        public string Product
        {
            get { return product; }
            set { product = value; }
        }

        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private String cost;

        public String Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private string cash;

        public string Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        private string credit;

        public string Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        public string client;

        public string Client
        {
            get { return client; }
            set { client = value; }
        }
    }
}
