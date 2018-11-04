using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Models
{
    public class Description: ObservableObject
    {
        private string id;
        public string Id
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
    }
}
