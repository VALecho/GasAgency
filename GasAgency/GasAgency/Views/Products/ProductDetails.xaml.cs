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
	public partial class ProductDetails : ContentPage
	{
		public ProductDetails (ProductsAndCost productsAndCost)
		{
			InitializeComponent ();
            BindingContext = new ProductsCRUDViewModel(productsAndCost);
		}
	}
}