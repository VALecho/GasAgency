using GasAgency.Models;
using GasAgency.Views;
using GasAgency.Views.Products;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GasAgency.ViewModels.ManageProducts
{
    class ProductsListViewModel : BaseViewModel
    {
        public ICommand AddProductTappedCommand { get; set; }

        public ICommand DeleteProductTappedCommand { get; set; }

        public  ICommand ListItemTappedCommand { get; set; }

        private IEnumerable<ProductsAndCost> _productsAndCosts;
        public IEnumerable<ProductsAndCost> ProductsAndCosts
        {
            get { return _productsAndCosts; }
            set
            {
                _productsAndCosts = value;
                OnPropertyChanged("ProductsAndCosts");
            }
        }

        private ObservableCollection<ProductsAndCost> _productAndCosts;
        public ObservableCollection<ProductsAndCost> ProductAndCosts
        {
            get { return _productAndCosts; }
            set
            {
                _productAndCosts = value;
                OnPropertyChanged("ProductAndCosts");
            }
        }

        public ProductsListViewModel()
        {
            ProductsAndCosts = new ObservableCollection<ProductsAndCost>();
            ProductAndCosts = new ObservableCollection<ProductsAndCost>();
            MessagingCenter.Subscribe<ProductsCRUDViewModel>(this, "Data Updated", async (sender) =>
            {
                await GetProductsAndCosts();
            });
            MessagingCenter.Subscribe<ProductsListViewModel>(this, "Data Updated", async (sender) =>
            {
                await GetProductsAndCosts();
            });
            SaveProducts();
            AddProductTappedCommand = new Command(NavigateToAddProduct);
            ListItemTappedCommand = new Command(NavigateToProductDetailsPage);
            GetProductsAndCosts();
        }

        private async Task SaveProducts()
        {
            //await App.Database.SaveProductAsync(new Product { Name = "Taritas01", Description = "Some Product" });
            //var recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date});

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas02", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas03", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas04", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas05", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas06", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas07", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas08", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas09", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            //await App.Database.SaveProductAsync(new Product { Name = "Taritas10", Description = "Some Product" });
            //recentProduct = new ObservableCollection<Product>(await App.Database.GetProductsAsync()).Last();
            //await App.Database.SaveProductCostAsync(new ProductCost { ProductId = recentProduct.ProductId, Cost = 150, EffectiveFrom = DateTime.Now.Date });

            MessagingCenter.Send<ProductsListViewModel>(this, "Data Updated");
        }

        private void NavigateToProductDetailsPage(object obj)
        {
            
        }

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private void NavigateToAddProduct(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddProduct());
        }

        private async Task GetProductsAndCosts()
        {
            var Products = new ObservableCollection<Product>(await App.Database.GetProductsAsync());
            var ProductsCost = new ObservableCollection<ProductCost>(await App.Database.GetProductCostsAsync());

            ProductsAndCosts = from Prod in Products
                        join ProdCost in ProductsCost on Prod.ProductId equals ProdCost.ProductId
                        select new ProductsAndCost { CurrentProduct = Prod, CurrentProductCost = ProdCost};

            var result = Products;
            var result1 = ProductsCost;
            var result2 = ProductsAndCosts;
            ProductAndCosts = new ObservableCollection<ProductsAndCost>(ProductsAndCosts);
        }
    }
}
