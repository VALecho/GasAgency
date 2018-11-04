using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class Hawker : ObservableObject
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }


        private int externalId;

        public int ExternalId
        {
            get { return externalId; }
            set { externalId = value;
                OnPropertyChanged("ExternalId");
            }
        }


        private string addressLine1;
        public string AddressLine1
        {
            get { return addressLine1; }
            set
            {
                addressLine1 = value;
                OnPropertyChanged("AddressLine1");
            }
        }


        private string addressline2;
        public string AddressLine2
        {
            get { return addressline2; }
            set
            {
                addressline2 = value;
                OnPropertyChanged("AddressLine2");
            }
        }


        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }


        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set
            {
                mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        private DateTime joiningDate;

        public DateTime JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value;
                OnPropertyChanged("JoiningDate");
            }
        }
    }
}
