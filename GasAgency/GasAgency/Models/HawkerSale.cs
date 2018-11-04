using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class HawkerSale : ObservableObject
    {

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        
        private Hawker hawker;
        public Hawker Hawker
        {
            get { return hawker; }
            set
            {
                hawker = value;
                OnPropertyChanged("Hawker");
            }
        }

        private Product product;
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }


        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }


        private double cost;
        public double Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }


        private TransactionMode transactionMode;
        public TransactionMode TransactionMode
        {
            get { return transactionMode; }
            set
            {
                transactionMode = value;
                OnPropertyChanged("TransactionMode");
            }
        }


        private Client client;
        public Client Client
        {
            get { return client; }
            set
            {
                if (value != null)
                    client = value;
                else
                    client = null;
                OnPropertyChanged("Client");
            }
        }

        private DateTime timeStamp;
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set
            {
                timeStamp = value;
                OnPropertyChanged("TimeStamp");
            }
        }
    }
}
