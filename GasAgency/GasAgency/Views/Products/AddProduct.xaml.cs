using GasAgency.ViewModels.ManageProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasAgency.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProduct : ContentPage
	{
		public AddProduct ()
		{
			InitializeComponent ();
            this.BindingContext = new ProductsCRUDViewModel();
		}
	}
}