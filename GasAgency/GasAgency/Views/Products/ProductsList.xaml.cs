using GasAgency.Models;
using GasAgency.ViewModels.ManageProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views.Products
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductsList : ContentPage
	{
		public ProductsList ()
		{
			InitializeComponent ();
            this.BindingContext = new ProductsListViewModel();
		}

        private void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ProductDetails(((ProductsAndCost)e.Item)));
            ((ListView)sender).SelectedItem = null;
        }
    }
}