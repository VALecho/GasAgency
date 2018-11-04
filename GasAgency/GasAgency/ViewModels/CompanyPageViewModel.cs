using GasAgency.Helpers;
using GasAgency.Models;
using GasAgency.Views;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels
{
    public class CompanyPageViewModel: BaseViewModel
    {
        public ICommand NewSaleCommand { get; set; }
        public ICommand NewExpenseCommand { get; set; }

        private ObservableCollection<SaleProductCostClient> _salesView;
        public ObservableCollection<SaleProductCostClient> SalesView
        {
            get { return _salesView; }
            set
            {
                _salesView = value;
                OnPropertyChanged("SalesView");
            }
        }

        private ObservableCollection<Sale> sales;
        public ObservableCollection<Sale> Sales
        {
            get
            {
                return sales;
            }
            set
            {
                sales = value;
                OnPropertyChanged("Sales");
            }
        }

        public ObservableCollection<Expense> Expenses { get; set; }

        public CompanyPageViewModel()
        {
            NewSaleCommand = new Command(NavigateToNewSalePage);
            NewExpenseCommand = new Command(NavigateToNewExpensePage);
            Sales = new ObservableCollection<Sale>();
            ICommand LoadSalesCommand = new Command(async () => await LoadSales());
            LoadSalesCommand.Execute(new Command(async () => await LoadSales()));
            MessagingCenter.Subscribe<SaleViewModel>(this, "Data Updated", async (sender) => await LoadSales());
            MessagingCenter.Subscribe<ExpenseViewModel>(this, "Data Updated", async (sender) => await LoadExpenses());
            Expenses = new ObservableCollection<Expense>();
        }

        private async Task LoadExpenses()
        {
            Expenses = new ObservableCollection<Expense>(await App.Database.GetExpensesAsync());
        }

        private async Task LoadSales()
        {
            Sales = new ObservableCollection<Sale>(await App.Database.GetSalesAsync());
            var Products = new ObservableCollection<Product>(await App.Database.GetProductsAsync());
            var ProductsCost = new ObservableCollection<ProductCost>(await App.Database.GetProductCostsAsync());
            var Clients = new ObservableCollection<Client>(await App.Database.GetClientsAsync());
            DateTime date = DateTime.Now.Date;
            var result = from sale in Sales where sale.TimeStamp == date
                         join prod in Products on sale.ProductId equals prod.ProductId
                         join prodCost in ProductsCost on sale.ProductId equals prodCost.ProductId
                         join client in Clients on sale.ClientId equals client.ClientId
                         select new SaleProductCostClient{ Product = prod, Sale = sale, Client = client, ProductCost = prodCost};

            SalesView = new ObservableCollection<SaleProductCostClient>(result);

        }

        private void NavigateToNewExpensePage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewExpense());
        }

        private void NavigateToNewSalePage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewSale()); 
        }
    }
}
