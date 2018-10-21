using GasAgency.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModel
{
    class OfficePageViewModel: BaseViewModel
    {
        public ICommand NewSalesTappedCommand;
        public ICommand NewExpenseTappedCommand;

        public ObservableCollection<Sales> OfficeSales = new ObservableCollection<Sales>();
        public ObservableCollection<Expense> OfficeExpenses = new ObservableCollection<Expense>();

        public OfficePageViewModel()
        {
            NewSalesTappedCommand = new Command(NavigateToNewSalesPage);
            NewExpenseTappedCommand = new Command(NavigateToNewExpensePage);

            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1"});
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });
            OfficeSales.Add(new Sales { Product = "14.2KG", Quantity = "10", Cost = "8700", Cash = "5000", Credit = "3700", Client = "Client-1" });

            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
            OfficeExpenses.Add(new Expense { Description = "Repair work", Cost = "100/-" });
        }

        private void NavigateToNewExpensePage(object obj)
        {
            throw new NotImplementedException();
        }

        private void NavigateToNewSalesPage(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
