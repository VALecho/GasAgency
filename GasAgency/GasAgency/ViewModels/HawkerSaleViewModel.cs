using GasAgency.Models;
using GasAgency.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels
{
    public class HawkerSaleViewModel: BaseViewModel
    {
        public ICommand NewSaleCommand { get; set; }

        public ObservableCollection<HawkerSale> HawkerSales { get; set; }

        public HawkerSaleViewModel()
        {
            NewSaleCommand = new Command(NavigateToNewHawkerSalePage);
            HawkerSales = new ObservableCollection<HawkerSale>();
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Pandey"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Mishra"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju"}, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
        }

        private void NavigateToNewHawkerSalePage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewHawkerSale());
        }
    }
}
