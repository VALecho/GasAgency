using GasAgency.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GasAgency.ViewModels
{
    public class CreditDetailsViewModel: BaseViewModel
    {
        public ObservableCollection<CreditDetail> CreditDetails { get; set; }
        
        public CreditDetailsViewModel()
        {
            CreditDetails = new ObservableCollection<CreditDetail>();
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
            CreditDetails.Add(new CreditDetail { Client = new Client { Name = "Taritas" }, Balance = 3000, Credit = 5000, Deposit = 2000});
        }
    }
}
