using GasAgency.Helpers;
using GasAgency.Models;
using GasAgency.Services;
using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels.ManageProducts
{
    public class ProductsCRUDViewModel: BaseViewModel
    {
        private bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if(isEnabled!=value)
                {
                    isEnabled = value;
                }
                OnPropertyChanged("IsEnabled");
            }
        }
        private Product _currentProduct;

        public Product CurrentProduct
        {
            get
            {
                return _currentProduct;
            }
            set
            {
                _currentProduct = value;
                OnPropertyChanged("CurrentProduct");
            }
        }

        private ProductCost _currentProductCost;

        public ProductCost CurrentProductCost
        {
            get
            {
                return _currentProductCost;
            }
            set
            {
                _currentProductCost = value;
                OnPropertyChanged("CurrentProductCost");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private double _cost;

        public double Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged("Cost");
            }
        }

        private DateTime _effectiveFrom;

        public DateTime EffectiveFrom
        {
            get { return _effectiveFrom; }
            set
            {
                _effectiveFrom = value;
                OnPropertyChanged("EffectiveFrom");
            }
        }

        public ICommand CreateProductCommand { get; set; }
        public ICommand GetProductCommand { get; set; }
        public ICommand GetProductCostCommand { get; set; }
        public ICommand SaveTappedCommand { get; set; }
        public ICommand ClearTappedCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }

        public ProductsCRUDViewModel()
        {
            CreateProductCommand = new Command(async()=> await AddProduct());
            ClearTappedCommand = new Command(async () => await ClearInputs());
            SaveTappedCommand = new Command(async () => await SaveProduct());
            DeleteProductCommand = new Command(async() => await DeleteProduct());
        }

        private async Task ClearInputs()
        {
            Name = null;
            Description = null;
            Cost = 0;
            EffectiveFrom = DateTime.Now.Date;
        }

        public ProductsCRUDViewModel(ProductsAndCost productsAndCost)
        {
            IsEnabled = false;
            CurrentProduct = new Product();
            CurrentProductCost = new ProductCost();
            DeleteProductCommand = new Command(async () => await DeleteProduct());
            UpdateProductCommand = new Command(async () => await UpdateProduct());
            SaveTappedCommand = new Command(async () => await SaveProduct());
            ClearTappedCommand = new Command(async () => await ClearEdits(productsAndCost));
            GetProductCommand = new Command(async () => await GetProduct(productsAndCost.CurrentProduct.ProductId));
            GetProductCommand.Execute(new Command(async () => await GetProduct(productsAndCost.CurrentProduct.ProductId)));
            GetProductCostCommand = new Command(async () => await GetProductCost(productsAndCost.CurrentProductCost.ProductId));
            GetProductCostCommand.Execute(new Command(async () => await GetProductCost(productsAndCost.CurrentProductCost.ProductId)));
        }

        private async Task ClearEdits(ProductsAndCost productsAndCost)
        {
            CurrentProduct = await App.Database.GetProductAsync(productsAndCost.CurrentProduct.ProductId);
            CurrentProductCost = await App.Database.GetProductCostAsync(productsAndCost.CurrentProduct.ProductId);
        }

        private async Task GetProductCost(int productId)
        {
           CurrentProductCost = await App.Database.GetProductCostAsync(productId);
        }

        private async Task SaveProduct()
        {
            await App.Database.SaveProductAsync(CurrentProduct);
            MessagingCenter.Send<ProductsCRUDViewModel>(this, "Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task GetProduct(int id)
        {
            CurrentProduct = await App.Database.GetProductAsync(id);
        }

        private async Task UpdateProduct()
        {
            IsEnabled = true;
        }
        
        private async Task DeleteProduct()
        {
            var result = await App.Current.MainPage.DisplayAlert($"Delete {CurrentProduct.Name}", $"Are you sure you want to delete {CurrentProduct.Name}", "Yes","No");
            if(result)
            {
                await App.Database.DeleteProductAsync(CurrentProduct);
                MessagingCenter.Send<ProductsCRUDViewModel>(this, "Data Updated");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async Task AddProduct()
        {
            CurrentProduct = new Product(); CurrentProductCost = new ProductCost();
            CurrentProduct.Name = Name;
            CurrentProduct.Description = Description;
            CurrentProductCost.Cost = Cost;
            CurrentProductCost.EffectiveFrom = EffectiveFrom;
            await App.Database.SaveProductAsync(CurrentProduct);
            var recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            CurrentProductCost.ProductId = recentProduct.ProductId;
            await App.Database.SaveProductCostAsync(CurrentProductCost);
            MessagingCenter.Send<ProductsCRUDViewModel>(this, "Data Updated");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
