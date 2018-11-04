using GasAgency.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels
{
    public class SaleViewModel: BaseViewModel
    {
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand LoadProductsCommand { get; set; }
        public ICommand LoadClientsCommand { get; set; }
        public ICommand LoadModesCommand { get; set; }
        public ICommand LoadProductsCostCommand { get; set; }

        private Sale currentSale;
        public Sale CurrentSale
        {
            get { return currentSale; }
            set { currentSale = value; }
        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        private ObservableCollection<ProductCost> productsCost;
        public ObservableCollection<ProductCost> ProductsCost
        {
            get { return productsCost; }
            set { productsCost = value; }
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
            set { selectedMode = value;
                OnPropertyChanged("SelectedMode");
            }
        }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get { return clients; }
            set { clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public SaleViewModel()
        {
            try
            {
                if (CurrentSale != null)
                {
                    CurrentSale = new Sale();
                }
                CancelCommand = new Command(CancelSaveNewSale);
                SaveCommand = new Command(async()=> await SaveNewSale());

                LoadProductsCommand = new Command(async()=>await GetProducts());
                LoadProductsCommand.Execute(new Command(async()=>await GetProducts()));

                LoadClientsCommand = new Command(async()=>await GetClients());
                LoadClientsCommand.Execute(new Command(async()=>await GetClients()));

                LoadModesCommand = new Command(async()=>await GetModes());
                LoadModesCommand.Execute(new Command(async()=>await GetModes()));

                LoadProductsCostCommand = new Command(async()=>await GetProductsCost());
                LoadProductsCostCommand.Execute(new Command(async()=>await GetProductsCost()));
            }
            catch (Exception ex)
            {
                var t = ex.Message;
                throw;
            }
        }

        private void CancelSaveNewSale(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task SaveNewSale()
        {
            //TODO need to get the data to add into Sales
            if(SelectedMode==TransactionMode.Credit)
            {
                if(String.IsNullOrEmpty(SelectedClient.Name))
                {
                    await App.Current.MainPage.DisplayAlert("Client Name is Empty","Client name cannot be empty when mode is cash","OK");
                }
                else
                {
                    await SaveCurrentSale();
                }
            }
            else
            {
                await SaveCurrentSale();
            }
        }

        private async Task SaveCurrentSale()
        {
            CurrentSale = new Sale
            {
                ClientId = SelectedClient.ClientId,
                Cost = (await App.Database.GetProductCostAsync(SelectedClient.ClientId)).Cost,
                ProductId = (await App.Database.GetProductAsync(SelectedProduct.ProductId)).ProductId,
                Quantity = 20,
                TransactionMode = SelectedMode,
                TimeStamp = DateTime.Now.Date.Date
            };
            await App.Database.SaveSaleAsync(CurrentSale);
            MessagingCenter.Send<SaleViewModel>(this, "Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task GetModes()
        {
            if (this.Modes == null)
            {
                this.Modes = new List<string>(); 
            }

            Modes.Add("CASH");
            Modes.Add("CREDIT"); 
        }

        private async Task GetClients()
        {
            if (this.Clients == null)
            {
                this.Clients = new ObservableCollection<Client>(await App.Database.GetClientsAsync());
            }
        }

        private async Task GetProducts()
        {
            if (this.Products == null)
            {
                this.Products = new ObservableCollection<Product>(await App.Database.GetProductsAsync());
            }
        }

        private async Task GetProductsCost()
        {
            if (this.ProductsCost == null)
            {
                this.ProductsCost = new ObservableCollection<ProductCost>(await App.Database.GetProductCostsAsync());
            }
        }
    }
}
