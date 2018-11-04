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
    public class NewHawkerSaleViewModel : BaseViewModel
    {
        public ICommand AddNewHawkerSaleCommand { get; set; }
        public ICommand ClearNewHawkerSaleCommand { get; set; }
        public ICommand SaveNewHawkerSaleCommand { get; set; }
        public ObservableCollection<HawkerSale> HawkerSales { get; set; }

        private ObservableCollection<Hawker> hawkers;
        public ObservableCollection<Hawker> Hawkers
        {
            get { return hawkers; }
            set { hawkers = value; }
        }

        private Hawker selectedHawker;
        public Hawker SelectedHawker
        {
            get { return selectedHawker; }
            set
            {
                selectedHawker = value;
                OnPropertyChanged("SelectedHawker");
            }
        }

        private HawkerSale currentHawkerSale;
        public HawkerSale CurrentHawkerSale
        {
            get { return currentHawkerSale; }
            set { currentHawkerSale = value; }
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private IList<string> modes;

        public IList<string> Modes
        {
            get { return modes; }
            set { modes = value; }
        }

        private TransactionMode selectedMode;
        public TransactionMode SelectedMode
        {
            get { return selectedMode; }
            set
            {
                selectedMode = value;
                OnPropertyChanged("SelectedMode");
            }
        }

        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private Client selectedClient;

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public NewHawkerSaleViewModel()
        {
            GetHawkers();
            GetClients();
            GetModes();
            GetProducts();
            AddNewHawkerSaleCommand = new Command(AddNewHawkerSale);
            ClearNewHawkerSaleCommand = new Command(ClearNewHawkerSale);
            SaveNewHawkerSaleCommand = new Command(SaveNewHawkerSale);
            HawkerSales = new ObservableCollection<HawkerSale>();
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Pandey" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Mishra" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
            HawkerSales.Add(new HawkerSale { Hawker = new Models.Hawker { Name = "Raju" }, Client = new Client { Name = "Taritas" }, Cost = 200, Product = new Product { Name = "14.2" }, Quantity = 1, TimeStamp = DateTime.Now, TransactionMode = TransactionMode.Cash });
        }

        private void SaveNewHawkerSale(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClearNewHawkerSale(object obj)
        {
            SelectedClient.Name = "";
            SelectedProduct.Name = null;
            var item = obj as HawkerSale;
            item.Quantity = 0;
            item.Cost = 0;
        }

        private void AddNewHawkerSale(object obj)
        {
            //TODO need to get the data to add into Sales
            if (this.CurrentHawkerSale == null)
            {
                if (SelectedMode == TransactionMode.Credit)
                {
                    SelectedClient = new Client();
                    if (string.IsNullOrEmpty(SelectedClient.Name))
                    {
                        App.Current.MainPage.DisplayAlert("Client Name cannot be empty", "Transaction mode is Credit", "Cancel");
                    }
                    else
                    {
                        App.Current.MainPage.Navigation.PopAsync();
                    }
                }
            }
        }

        private void GetHawkers()
        {
            var foo = Hawkers;
            if (this.Hawkers == null)
            {
                this.Hawkers = new ObservableCollection<Hawker>();
            }

            Hawkers.Add(new Hawker { Name = "Raju" });
            Hawkers.Add(new Hawker { Name = "Mishra" });
            Hawkers.Add(new Hawker { Name = "Pandey" });
            Hawkers.Add(new Hawker { Name = "Raghu" });
            Hawkers.Add(new Hawker { Name = "Naresh" });
        }

        private void GetModes()
        {
            if (this.Modes == null)
            {
                this.Modes = new List<string>();
            }

            Modes.Add("CASH");
            Modes.Add("CREDIT");
        }

        private void GetClients()
        {
            if (this.Clients == null)
            {
                this.Clients = new ObservableCollection<Client>();
            }

            Clients.Add(new Client { Name = "Taritas 1" });
            Clients.Add(new Client { Name = "Taritas 2" });
            Clients.Add(new Client { Name = "Taritas 3" });
            Clients.Add(new Client { Name = "Taritas 4" });
            Clients.Add(new Client { Name = "Taritas 5" });
        }

        private void GetProducts()
        {
            if (this.Products == null)
            {
                this.Products = new ObservableCollection<Product>();
            }

            Products.Add(new Product { Name = "14.2 KG Cyllinder" });
            Products.Add(new Product { Name = "Ujjwala Connection" });
            Products.Add(new Product { Name = "Gas Stove 2 burners" });
            Products.Add(new Product { Name = "Gas Stove 3 burners" });
            Products.Add(new Product { Name = "Rubber Tube" });
            Products.Add(new Product { Name = "5 KG Cyllinder" });
        }
    }
}
